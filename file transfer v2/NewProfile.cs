using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file_transfer_v2
{
    public partial class NewProfile : Form
    {
        private XmlHandler xmlHandler;
        public NewProfile(XmlHandler xmlHandler1)
        {
            InitializeComponent();
            xmlHandler = xmlHandler1;
        }

        private void BtnCreateNewProfile_Click(object sender, EventArgs e)
        {
            if (TxtNewProfileName.Text != "")
            {
                xmlHandler.project.ProjectName = TxtNewProfileName.Text;
                xmlHandler.CreateNewProfile();
                this.Close();
            }
            else
            {
                LblError.Text = "No project name found";
                timer1.Start();
                
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            LblError.Text = "";
        }
    }
}
