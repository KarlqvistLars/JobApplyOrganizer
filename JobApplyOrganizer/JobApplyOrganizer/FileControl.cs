using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplyOrganizer
{

    public class FileControl
    {
        private String _programLocationPath = null;
        private String _workingdir = null;
        private JobApplication _japplication = new JobApplication("", "", "", "", "", "", "", "", "");
        private List<JobApplication> _jobList = new List<JobApplication>();
        public FileControl(String programLocationPath, String workingdir, JobApplication jApplication, List<JobApplication> jobList)
        {
            this._programLocationPath = programLocationPath;
            this._workingdir = workingdir;
            this._japplication = jApplication;
            this._jobList = jobList;
        }
        public String ProgramLocationPath { get; set; }
        public String Workingdir { get; set; }
        public JobApplication Japplication { get; set; }
        public List<JobApplication> JobList { get; set; }

        public List<JobApplication> WDScan()
        {
            // Scanna och ladda folders till joblist
            List<string> searchDirs = Directory.GetDirectories(Workingdir, "*.*").ToList();
            List<JobApplication> jobList = new List<JobApplication>();
            foreach (string folder in searchDirs)
            {
                JobApplication job = new JobApplication();
                String str1 = @"\\";
                String str2 = @"\";
                String f = folder.Replace(str1, str2);
                job.Path = f;

                //jobList = FilterActiveJobSearch(jobList);
                //Console.WriteLine(f + "HÄR SKA DET IN");

                if (folder.Contains("\\P20"))
                {
                    string separator = "\\P";
                    int num = folder.Split(separator.ToCharArray(0, 1)).Length;
                    String j = folder.Split(separator.ToCharArray(0, 1))[num - 1];
                    String[] jobPart = j.Split('_');
                    job.Path = folder.Replace("\\\\", "\\");
                    job.Name = jobPart[1];
                    job.Company = jobPart[2];
                    job.Htmlname = job.Path.Replace("\\\\", "\\") + "\\" + job.Name + "_" + job.Company + ".html";
                    //Console.WriteLine(String.Format("1 {0}, 2 {1}, 3 {2}, 4 {3}\n", job.Path, job.Name, job.Company, job.Htmlname));
                    job = OpenKontaktTXT(job.Path + @"\Kontakt.txt", job);
                    jobList.Add(job);
                }
            }

            return jobList;
        }
        public void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        public String CleanPath(String path, String StringIN, String StringUT)
        {
            String pathCleaned = path.Replace(StringIN, StringUT);
            return pathCleaned;
        }
        public String[] CreateJobPath(String programLocationPath, String templatePath, String jobPath)
        {
            // ifall job biblioteket ändras behöver men flytta ny templats till detta. 
            if (!Directory.Exists(templatePath))
            {
                Directory.CreateDirectory(templatePath);
                CopyDirectory(programLocationPath + @"\Templates\", templatePath, true);
            }

            if (!Directory.Exists(jobPath))
            {
                Directory.CreateDirectory(jobPath);
                CopyDirectory(templatePath, jobPath, true);
            }
            String[] fileList = Directory.GetFiles(jobPath);
            return fileList;
        }
        public JobApplication OpenKontaktTXT(String path, JobApplication jobapply)
        {
            String line;
            //Console.WriteLine(String.Format("### OpenKontaktTXT()\n### {0}\n### {1}\n### {2}\n### {3}\n### {4}", path, kontakt[0], kontakt[1], kontakt[2], kontakt[3]));
            try
            {
                int count = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (count == 0)
                    {
                        jobapply.Contact = line.StartsWith("Namn:") ? line.Remove(0, 5) : line;
                    }
                    else if (count == 1)
                    {
                        jobapply.Tele = line.StartsWith("Tele:") ? line.Remove(0, 5) : line;
                    }
                    else if (count == 2)
                    {
                        jobapply.Mail = line.StartsWith("Mail:") ? line.Remove(0, 5) : line;
                    }
                    else if (count == 3)
                    {
                        jobapply.URL = line.StartsWith("URL:") ? line.Remove(0, 5) : line;
                    }
                    line = sr.ReadLine();
                    count++;
                }
                Console.WriteLine("1 {0}\n2 {1}\n3 {2}\n4 {3}\n\n", jobapply.Contact, jobapply.Tele, jobapply.Mail, jobapply.URL);
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return jobapply;
        }
    }
}
