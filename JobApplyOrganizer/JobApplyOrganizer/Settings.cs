using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplyOrganizer
{
    public partial class Settings : Form
    {
        String _workingdir = null;
        public Settings(String workingdir)
        {
            InitializeComponent();
            _workingdir = workingdir;
            textBoxWorkDir.Text = _workingdir;
        }
        public string Workingdir { get; set; }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // TODO: Skriv koden för uppdatering
            this.Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            this.StartPosition = FormStartPosition.CenterParent;
            string dummyFileName = "Save Here";
            ofd.Title = "Select location for job applications";
            ofd.FileName = dummyFileName;
            ofd.CheckFileExists = false;
            ofd.InitialDirectory = this.textBoxWorkDir.Text;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBoxWorkDir.Text = Path.GetDirectoryName(ofd.FileName).ToLower();
            }
            this.Workingdir = this.textBoxWorkDir.Text.Trim();
        }
    }
}
