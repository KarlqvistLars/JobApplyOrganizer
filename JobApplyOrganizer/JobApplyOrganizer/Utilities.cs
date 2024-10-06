using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplyOrganizer
{
    internal class Utilities
    {
 
        static bool _setting = false;
        public Utilities()
        {
        }

        public String CleanPath(String path, String StringIN, String StringUT)
        {
            String pathCleaned = path.Replace(StringIN, StringUT);
            return pathCleaned;
        }

        public String[] CreateJobPath(String templatePath, String jobPath)
        {
            if (!Directory.Exists(jobPath))
            {
                Directory.CreateDirectory(jobPath);
                CopyDirectory(templatePath, jobPath, true);
            }
            String[] fileList = Directory.GetFiles(jobPath);
            foreach (var file in fileList)
            {
                Console.WriteLine(file);
            }
            return fileList;
        }

        public String[] OpenKontaktTXT(String path, String[] kontakt)
        {
            String line;
            Console.WriteLine(String.Format("### OpenKontaktTXT()\n### {0}\n### {1}\n### {2}\n### {3}\n### {4}", path, kontakt[0], kontakt[1], kontakt[2], kontakt[3]));
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line.StartsWith("Namn:"))
                    {
                        kontakt[0] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("Tele:"))
                    {
                        kontakt[1] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("Mail:"))
                    {
                        kontakt[2] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("URL:"))
                    {
                        kontakt[3] = line.Remove(0, 4);
                        Console.WriteLine(" URL link: {0}", kontakt[3]);
                    }
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
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
            return kontakt;
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
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
    }
}
