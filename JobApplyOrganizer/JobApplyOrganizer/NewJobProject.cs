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
        public NewJobProject(String[] payload)
        {
            InitializeComponent();
            labelJobtitle.Text = payload[0];
            labelCompany.Text = payload[1];
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
