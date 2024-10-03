using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JobApplyOrganizer
{
    public partial class MainJobApplyOrganizer : Form
    {
        // parameters
        List<JobApplication> jobList = new List<JobApplication> ();
        String installpath = null;

        public MainJobApplyOrganizer()
        {
            InitializeComponent();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(".\\config.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line + " init");
                    //Read the next line
                    installpath = line;
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

        }

        private void MainJobApplyOrganizer_Load(object sender, EventArgs e)
        {
            // TODO: Vad händer vid program start? LAdda bibliotek samt pojekt mm.
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            //String installpath = "C:\\PROJEKT\\2024\\24019_JobApplyOrganizer";
            JobApplication jobApplication = new JobApplication();
            String[] payload = new string[2];
            payload[0]= textBoxJobTitle.Text;
            payload[1]= textBoxCompany.Text;
            Console.WriteLine(" *************** " + installpath);
            NewJobProject newJobProject = new NewJobProject(payload, jobApplication, installpath);
            newJobProject.ShowDialog();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Updatera
            Console.WriteLine("\n***** Post is Updated *****\n");
        }

        private void ButtonOpenHTML_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Öppna URL
            Console.WriteLine("\n***** Post is Opened *****\n");
        }

        private void ButtonMoveToArkiv_Click(object sender, EventArgs e)
        {
            // TODO: Skapa denna funktion Flytta till arkiv
            Console.WriteLine("\n***** Post is Moved to archive *****\n");
        }
    }
}
