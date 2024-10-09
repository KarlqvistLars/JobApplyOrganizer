using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace JobApplyOrganizer
{
    public partial class MainJobApplyOrganizer : Form
    {
        // parameters
        List<JobApplication> jobList = new List<JobApplication>();
        FileControl fileCTRL = new FileControl("", "", new JobApplication("", "", "", "", "", "", "", "", ""), new List<JobApplication>());
        readonly Utilities utils = new Utilities();
        String OpenHTML = null;
        String[] kontakt = new String[4];
        int selectedIndex = 0;
        enum FileOp
        {
            SAVE = 0,
            WRITE = 1,
        }
        enum Type
        {
            NEW = 0,
            EDIT = 1,
        }
        public MainJobApplyOrganizer()
        {
            InitializeComponent();
            fileCTRL.ProgramLocationPath = Environment.GetCommandLineArgs()[0].Replace("JobApplyOrganizer.exe", "");
        }
        // Buttons
        private void MainJobApplyOrganizer_Load(object sender, EventArgs e)
        {
            // TODO: Vad händer vid program start? LAdda bibliotek samt pojekt mm.
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("<<<<<<<<<<<<<< PROGRAM START >>>>>>>>>>>>>>");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(fileCTRL.ProgramLocationPath);
            LoadConfig();
            string root = @"c:\";
            // If directory does not exist, don't even try   
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
                //Directory.CreateDirectory(root + @"Templates\");
                utils.CreateJobPath(fileCTRL.ProgramLocationPath, fileCTRL.ProgramLocationPath + @"Templates\", root + @"Templates\");
            }
            PopulateListBox(fileCTRL.Workingdir);

        }
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Boolean newJob = true;
            foreach (var item in jobList)
            {
                if (item.Name.Trim() == textBoxJobTitle.Text.Trim() && item.Company.Trim() == textBoxCompany.Text.Trim())
                    newJob = false;
            }
            if (textBoxJobTitle.Text != "" && newJob)
            {
                JobApplication jobApplication = new JobApplication();
                String[] payload = new string[9];
                payload[0] = textBoxJobTitle.Text;
                payload[1] = textBoxCompany.Text;
        
                NewJobProject newJobProject = new NewJobProject(Type.NEW, payload, fileCTRL.Workingdir, fileCTRL.ProgramLocationPath);
                if (newJobProject.ShowDialog() == DialogResult.OK)
                {
                    PopulateListBox(fileCTRL.Workingdir);
                }
            }
            listBoxJobsInProgress.Items.Clear();
            PopulateListBox(fileCTRL.Workingdir);
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Updatera
            if (textBoxJobTitle.Text != "")
            {
                JobApplication jobApplication = null;
                jobApplication = LoadActiveContact();
                Console.WriteLine("1 {0}\n2 {1}\n3 {2}\n4 {3}\n5 {4}\n6 {5}\n7 {6}\n", jobApplication.Path, jobApplication.Name, jobApplication.Htmlname, jobApplication.Contact, jobApplication.Tele, jobApplication.Mail, jobApplication.URL);
                //Console.WriteLine(activPath);
                int index = 0;
                string datum = "";
                foreach (var item in listBoxJobsInProgress.Items)
                {
                    if (index == selectedIndex)
                    {
                        datum = item.ToString().Substring(0, 8);
                    }
                    index++;
                };
                String[] payload = new string[7];
                jobApplication.Name = textBoxJobTitle.Text;
                jobApplication.Company = textBoxCompany.Text;
                payload[0] = jobApplication.Name;
                payload[1] = jobApplication.Company;
                payload[2] = jobApplication.Contact;
                payload[3] = jobApplication.Tele;
                payload[4] = jobApplication.Mail;
                payload[5] = jobApplication.URL;
                payload[6] = datum;

                NewJobProject newJobProject = new NewJobProject(Type.EDIT, payload, fileCTRL.Workingdir, fileCTRL.ProgramLocationPath);

                if (newJobProject.ShowDialog() == DialogResult.OK)
                {
                    String[] jobA = newJobProject.JobApp;

                    Console.WriteLine(jobA);
                    UpdateForm(jobA);
                }
            }
            listBoxJobsInProgress.Items.Clear();
            PopulateListBox(fileCTRL.Workingdir);
            Console.WriteLine("\n***** Post is Updated *****\n");
        }
        private void UpdateForm(String[] job)
        {
            Console.WriteLine("OK");
            textBoxJobTitle.Text = job[1];
            textBoxCompany.Text = job[2];
            labelName.Text = job[3];
            labelTele.Text = job[4];
            labelEmail.Text = job[5];
        }
        private void ButtonOpenHTML_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Öppna URL
            Console.WriteLine("\n***** Post is Opened *****\n");
            Boolean exsist = false;
            foreach (var item in jobList)
            {
                if ((item.Name.Trim() == textBoxJobTitle.Text.Trim() && item.Company.Trim() == textBoxCompany.Text.Trim()))
                    exsist = true;
            }
            if (exsist)
            {
                Uri uri = new System.Uri(OpenHTML);
                Console.WriteLine(uri);
                string converted = uri.AbsoluteUri;
                // Navigate to a URL.
                try
                {
                    string browserPath = GetPathToDefaultBrowser();
                    Process.Start(browserPath, converted);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed to open HTML: {OpenHTML}");
                    throw;
                }
            }
        }
        private void ButtonMoveToArkiv_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Flytta till arkiv
            Console.WriteLine("\n***** Post is Moved to archive *****\n");
            int index = 0;
            String temp = "";
            List<JobApplication> list = new List<JobApplication>();
            foreach (var item in jobList)
            {
                if (index == selectedIndex)
                {
                    Console.WriteLine(item.Path);
                    temp = item.Path + "\\";
                    item.Path = item.Path.Replace("P2", "2") + "\\";
                    Console.WriteLine(item.Path);

                    Directory.CreateDirectory(item.Path);
                    CopyDirectory(temp, item.Path, true);
                    foreach (var item1 in Directory.GetFiles(temp))
                    {
                        Console.WriteLine(item1.ToString());
                        File.Delete(item1);
                    }
                    Directory.Delete(temp);
                    listBoxJobsInProgress.Items.Clear();
                    PopulateListBox(fileCTRL.Workingdir);
                    textBoxJobTitle.Clear();
                    textBoxCompany.Clear();
                }
                list.Add(item);
                index++;
            }
            jobList = list;
        }
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            String templatePath = fileCTRL.Workingdir + "\\Templates\\";
            Settings settings = new Settings(fileCTRL.Workingdir, templatePath);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                fileCTRL.Workingdir = settings.Workingdir;
                //MessageBox.Show(settings.fileCTRL.Workingdir);
                Console.WriteLine("Test " + fileCTRL.Workingdir);
                PopulateListBox(fileCTRL.Workingdir);
                SaveConfig();
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            SaveConfig();
            this.Close();
        }
        // Helper funcs
        private void LoadConfig()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader((fileCTRL.ProgramLocationPath+"config.txt").Replace("\\", "\\\\"));
                StreamReader sr = new StreamReader(".\\config.txt");
                //Console.WriteLine((fileCTRL.ProgramLocationPath + "config.txt").Replace("\\", "\\\\"));
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    fileCTRL.Workingdir = line;
                    line = sr.ReadLine();
                    //installpath = line;
                }
                //close the file
                sr.Close();
                Console.ReadLine();
                //Console.WriteLine(installpath);
                //fileCTRL.Workingdir = installpath;
                //"C:\\PROJEKT\\2024\\24019_JobApplyOrganizer\\TestSandbox\\";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        private void SaveConfig()
        {
            // TODO: Updatera filhanteringen till 
            //File.Delete(fileCTRL.ProgramLocationPath + "config.txt");
            fileCTRL.Workingdir = utils.CleanPath(fileCTRL.Workingdir, "\\\\", "\\");
            using (StreamWriter sw = File.CreateText(fileCTRL.ProgramLocationPath + "config.txt"))
            {
                try
                {
                    sw.WriteLine(fileCTRL.Workingdir);
                    //Console.WriteLine(" TTT "+ fileCTRL.Workingdir);
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
        private JobApplication LoadActiveContact()
        {
            String path = "";
            JobApplication jobApplication = new JobApplication();
            jobList = fileCTRL.WDScan();
            int index = 0;
            foreach (var item in jobList)
            {
                if (index == selectedIndex)
                {
                    //path = item.Path;
                    //jobApplication.Path = path;
                    jobApplication = item;
                }
                index++;
            }
            Console.WriteLine("\n\n LoadActiveContact() " + path);
            //kontakt = utils.OpenKontaktTXT(path, kontakt);
            return jobApplication;
        }
        private List<JobApplication> ScanJobsPath(String path)
        {
            // Scanna och ladda folders till joblist
            List<string> searchDirs = Directory.GetDirectories(path, "*.*").ToList();
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
                    jobList.Add(job);
                }
            }

            return jobList;
        }
        private void PopulateListBox(String installpath)
        {
            this.listBoxJobsInProgress.Items.Clear();
            jobList = ScanJobsPath(installpath);

            foreach (var item in jobList)
            {
                if (item.Path != "")
                {
                    String populatelist = (item.Path).Split('\\')[(item.Path).Split('\\').Count() - 1];
                    populatelist = populatelist.Replace("P2", "2");
                    //Console.WriteLine(populatelist.IndexOf("_"));
                    String list1 = populatelist.Substring(0, 8);
                    String list2 = populatelist.Remove(0, 9);
                    populatelist = list1 + "   " + list2;
                    this.listBoxJobsInProgress.Items.Add(populatelist);
                }
            }
        }
        private void ListBoxJobsInProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulateListBox(fileCTRL.Workingdir);
            //this.listBoxJobsInProgress.Update();
            int count = 0;
            int len = fileCTRL.Workingdir.Length;
            foreach (var item in jobList)
            {
                if (count == listBoxJobsInProgress.SelectedIndex)
                {
                    selectedIndex = listBoxJobsInProgress.SelectedIndex;
                    string tempPath = utils.CleanPath(item.Path, "\\\\", "\\");
                    labelActiveJobPath.Text = tempPath.Remove(0, len + 1);
                    textBoxJobTitle.Text = item.Name;
                    textBoxCompany.Text = item.Company;
                    OpenHTML = item.Path + "\\" + textBoxJobTitle.Text + ".html";
                    ContactsUpdate(item.Path, 0, item);
                }
                count++;
            }
            //listBoxJobsInProgress.Items.Clear();
            PopulateListBox(fileCTRL.Workingdir);
            //this.listBoxJobsInProgress.Update();
            this.label1.Text = selectedIndex.ToString();
        }
        private JobApplication ContactsUpdate(string path, int file, JobApplication jobApplication)
        {
            path = path + "\\Kontakt.txt";
            path = path.Replace("\\", "\\\\");
            //Console.WriteLine(path);
            if (file == 0)
            {
                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(path);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    labelNamn.Text = "";
                    labelTele.Text = "";
                    labelEmail.Text = "";
                    while (line != null)
                    {
                        if (line.StartsWith("Namn:"))
                        {
                            labelNamn.Text = line.Remove(0, 5);
                            jobApplication.Contact = line.Remove(0, 5);
                        }
                        else if (line.StartsWith("Tele:"))
                        {
                            labelTele.Text = line.Remove(0, 5);
                            jobApplication.Tele = line.Remove(0, 5);
                        }
                        else if (line.StartsWith("Mail:"))
                        {
                            labelEmail.Text = line.Remove(0, 5);
                            jobApplication.Mail = line.Remove(0, 5);
                        }
                        else if (line.StartsWith("URL:"))
                        {
                            jobApplication.URL = line.Remove(0, 4);
                        }

                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            else if (file == 1)
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    try
                    {
                        sw.WriteLine(String.Format("Namn: {0}\n", jobApplication.Contact));
                        sw.WriteLine(String.Format("Tele: {0}\n", jobApplication.Tele));
                        sw.WriteLine(String.Format("Mail: {0}\n", jobApplication.Mail));
                        sw.WriteLine(String.Format("URL: {0}\n", jobApplication.URL));
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
                }
            }
            return jobApplication;
        }
        /// <summary>
        /// Returns the path to the current default browser
        /// </summary>
        /// <returns></returns>
        private static string GetPathToDefaultBrowser()
        {
            const string currentUserSubKey =
            @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(currentUserSubKey, false))
            {
                string progId = (userChoiceKey.GetValue("ProgId").ToString());
                using (RegistryKey kp =
                       Registry.ClassesRoot.OpenSubKey(progId + @"\shell\open\command", false))
                {
                    // Get default value and convert to EXE path.
                    // It's stored as:
                    //    "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" -- "%1"
                    // So we want the first quoted string only
                    string rawValue = (string)kp.GetValue("");
                    Regex reg = new Regex("(?<=\").*?(?=\")");
                    Match m = reg.Match(rawValue);
                    return m.Success ? m.Value : "";
                }
            }
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
