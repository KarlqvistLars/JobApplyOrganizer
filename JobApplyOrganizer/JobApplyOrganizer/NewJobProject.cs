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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace JobApplyOrganizer
{
    public partial class NewJobProject : Form
    {
        DateTime date = new DateTime();
        Utilities Util = new Utilities();
        enum Type
        {
            NEW = 0,
            EDIT = 1,
        }

        String[] _jobApp = new String[9];
        String _workdirpath = "";
        String _programLocationPath = "";
        String FOLDERname = "";
        String HTMLname = "";
        String _date = "";
        List<JobApplication> jobNewList = new List<JobApplication>();
        Enum _type = Type.NEW;
        public NewJobProject(Enum type, String[] jobApp, String workdirpath, String programLocationPath)
        {
            InitializeComponent();
            this._type = type;
            _jobApp = jobApp;

            if (type.ToString() == Type.NEW.ToString())
            {
                this.Text = "New";
                buttonCreate.Text = "Create";
            }
            else if (type.ToString() == Type.EDIT.ToString())
            {
                this.Text = "Edit";
                buttonCreate.Text = "Update";
            }
            textJobtitle.Text = jobApp[0];
            textCompany.Text = jobApp[1];
            textBoxName.Text = jobApp[2];
            textBoxPhone.Text = jobApp[3];
            textBoxEmail.Text = jobApp[4];
            textBoxURL.Text = jobApp[5];
            _date = jobApp[6];

            Console.WriteLine("P "+ jobApp[5] + " P");

            this.FOLDERname = textJobtitle.Text + "_" + textCompany.Text;
            this.HTMLname = textJobtitle.Text;
            this._workdirpath = workdirpath;
            this._programLocationPath = programLocationPath;
            Console.WriteLine(" -+- "+workdirpath + " " + programLocationPath);
        }

        public JobApplication Jobapplication { get; set; }

        public String[] JobApp { get; set; }
        
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            MakeHTML pageHtml = new MakeHTML();
            String[] inDataHtml = new String[9];
            if (_type.ToString() == Type.NEW.ToString())
            {
                date = DateTime.Now;
                // jobPath
                inDataHtml[0] = this._workdirpath + "\\P" + date.ToString("yyyyMMdd") + "_" + FOLDERname + "\\";
                // templatePath
                inDataHtml[1] = this._workdirpath + "\\Templates\\";
                // html filename
                inDataHtml[2] = inDataHtml[0] + HTMLname;
                // pagename
                inDataHtml[3] = textBoxName.Text;
                inDataHtml[4] = textBoxPhone.Text;
                inDataHtml[5] = textBoxEmail.Text;
                inDataHtml[6] = textBoxURL.Text;
                inDataHtml[7] = this.HTMLname;
                inDataHtml[8] = this._programLocationPath;
                Console.WriteLine("inDataHtml\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}", inDataHtml[0], inDataHtml[1], inDataHtml[2], inDataHtml[3], inDataHtml[4], inDataHtml[5], inDataHtml[6], inDataHtml[7], inDataHtml[8]);
                pageHtml.CreateHTML(inDataHtml);
                String[] returNew = this.FOLDERname.Split('_');
                inDataHtml[1] = returNew[0];
                inDataHtml[2] = returNew[1];
                JobApp = inDataHtml;

            }
            else if (_type.ToString() == Type.EDIT.ToString())
            {
                // jobPath
                inDataHtml[0] = this._workdirpath + "\\P" + _date + "_" + FOLDERname + "\\";
                // templatePath
                inDataHtml[1] = this._workdirpath + "\\Templates\\";
                // html filename
                inDataHtml[2] = inDataHtml[0] + HTMLname;
                // pagename
                inDataHtml[3] = textBoxName.Text;
                inDataHtml[4] = textBoxPhone.Text;
                inDataHtml[5] = textBoxEmail.Text;
                inDataHtml[6] = textBoxURL.Text;
                inDataHtml[7] = this.HTMLname;

                String dateStr = inDataHtml[0];
                int len = this._workdirpath.Length;
                //dateStr = dateStr.Replace( , len);

                Console.WriteLine(" KOLLA HÄR " + FOLDERname + " ???");

                String temp = Util.CleanPath((inDataHtml[0] + HTMLname + ".html"), "\\\\", "\\");

                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
                pageHtml.CreateHTML(inDataHtml);
            }
            String[] retur = this.FOLDERname.Split('_');
            inDataHtml[1] = retur[0];
            inDataHtml[2] = retur[1];
            JobApp = inDataHtml;
            this.Close();
        }
        private void SaveKontaktTXT(String path)
        {
            String Name_ = textBoxName.Text;
            String Phone_ = textBoxPhone.Text;
            String Email_ = textBoxEmail.Text;
            String URL_ = textBoxURL.Text;
            // Create a file to write to.

            String cleanedPath = Util.CleanPath(path + "\\Kontakt.txt", @"\\", "\\");

            using (StreamWriter sw = File.CreateText(cleanedPath))
            {
                try
                {
                    sw.WriteLine(String.Format("Namn: {0}", Name_.Trim()));
                    sw.WriteLine(String.Format("Tele: {0}", Phone_.Trim()));
                    sw.WriteLine(String.Format("Mail: {0}", Email_.Trim()));
                    sw.WriteLine(String.Format("URL: {0}", URL_.Trim()));
                    sw.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine("Exception: " + err.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

                this.Close();
            }
        }
    }
}
