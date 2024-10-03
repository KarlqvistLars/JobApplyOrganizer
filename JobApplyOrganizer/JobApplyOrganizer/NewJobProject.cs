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

    public partial class NewJobProject : Form
    {
        DateTime date = new DateTime();
        JobApplication application = new JobApplication();
        String installpath = "";
        String pagename = "";
       

        public NewJobProject(String[] payload, JobApplication jobApplication, String installpath)
        {
            InitializeComponent();
            textJobtitle.Text = payload[0];
            textCompany.Text = payload[1];

            this.pagename = textJobtitle.Text + textCompany.Text;
            this.installpath = installpath;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string namn = application.Path;
            MakeHTML pageHtml = new MakeHTML();
            date = DateTime.Now;
            pageHtml.CreateHTML(this.pagename, this.installpath, date);
            Console.WriteLine(date.ToString("yyyyMMdd"));
            this.Close();
        }
    }
}
