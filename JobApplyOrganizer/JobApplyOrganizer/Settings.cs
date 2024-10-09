using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        readonly String _workingdir = null;
        readonly String _templateDir = null;
        public Settings(String workingdir, String templateDir)
        {
            InitializeComponent();
            _workingdir = workingdir;
            _templateDir = templateDir;
            textBoxWorkDir.Text = _workingdir;
            labelTemplateDirectory.Text = _templateDir;
        }
        public string Workingdir { get; set; }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Workingdir = textBoxWorkDir.Text;
            // TODO: Skriv koden för uppdatering
            this.Close();
        }
        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            string path = String.Format(_workingdir);
            Console.WriteLine(path);
            var dlg = new FolderBrowserDialog { SelectedPath = path };
            
            using (dlg)
            {
                this.StartPosition = FormStartPosition.CenterParent;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.StartPosition = FormStartPosition.CenterParent;
                    Workingdir = dlg.SelectedPath;
                    textBoxWorkDir.Text = Workingdir;
                }
            }
        }
        private void buttonOpenDir_Click(object sender, EventArgs e)
        {
            if (IsValidPath(_templateDir))
            {
                if (Directory.Exists(@_templateDir))
                {
                    Process.Start("explorer.exe", @_templateDir);
                }
            }
        }
        private bool IsValidPath(string workingdir)
        {
            if (!Directory.Exists(@workingdir)) { return false; } else { return true; }
        }
    }
}
