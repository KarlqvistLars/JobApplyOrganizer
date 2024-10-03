using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplyOrganizer
{
    public partial class MainJobApplyOrganizer : Form
    {
        public MainJobApplyOrganizer()
        {
            InitializeComponent();
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
            String[] payload = new string[2];
            payload[0]= textBoxJobTitle.Text;
            payload[1]= textBoxCompany.Text;
            NewJobProject newJobProject = new NewJobProject(payload);
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
