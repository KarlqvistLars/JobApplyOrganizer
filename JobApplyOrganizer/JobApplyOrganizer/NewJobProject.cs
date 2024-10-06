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

    public partial class NewJobProject : Form
    {
        DateTime date = new DateTime();
        Utilities Util = new Utilities();
        enum Type
        {
            NEW = 0,
            EDIT = 1,
        }

        JobApplication application = new JobApplication();
        String installpath = "";
        String FOLDERname = "";
        String HTMLname = "";
        List<JobApplication> jobNewList = new List<JobApplication>();
        String[] returnLoad { get; set; }
        Enum _type = Type.NEW;
        public NewJobProject(Enum type, String[] payload, JobApplication jobApplication, String installpath)
        {
            InitializeComponent();
            this._type = type;
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
            textJobtitle.Text = payload[0];
            textCompany.Text = payload[1];
            textBoxName.Text = payload[2];
            textBoxPhone.Text = payload[3];
            textBoxEmail.Text = payload[4];
            textBoxURL.Text = payload[5];
            this.FOLDERname = textJobtitle.Text + "_" + textCompany.Text;
            this.HTMLname = textJobtitle.Text;
            this.installpath = installpath;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (_type.ToString() == Type.NEW.ToString())
            {
                date = DateTime.Now;
                String jobPath = this.installpath + "\\P" + date.ToString("yyyyMMdd") + "_" + FOLDERname + "\\";
                String templatePath = this.installpath + "\\Templates\\";
                String[] fileList = Util.CreateJobPath(templatePath, jobPath);

                SaveKontaktTXT(jobPath);
                MakeHTML pageHtml = new MakeHTML();
                String path = pageHtml.CreateHTML(fileList, this.HTMLname, jobPath, templatePath, date);
                Console.WriteLine(date.ToString("yyyyMMdd ") + installpath);
                Console.WriteLine(path);
            }
            else if (_type.ToString() == Type.EDIT.ToString())
            {
                date = DateTime.Now;
                String jobPath = this.installpath + "\\P" + date.ToString("yyyyMMdd") + "_" + FOLDERname + "\\";
                String templatePath = this.installpath + "\\Templates\\";
                String[] fileList = Util.CreateJobPath(templatePath, jobPath);
                SaveKontaktTXT(jobPath);
                Console.WriteLine(jobPath + HTMLname + "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                String temp = Util.CleanPath((jobPath + HTMLname), "\\\\", "\\");
                Console.WriteLine(temp + "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                temp = temp + ".html";
                File.Delete(temp);

                MakeHTML pageHtml = new MakeHTML();
                String path = pageHtml.CreateHTML(fileList, this.HTMLname, jobPath, templatePath, date);
                Console.WriteLine(date.ToString("yyyyMMdd ") + installpath);
                Console.WriteLine(path);
            }


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
