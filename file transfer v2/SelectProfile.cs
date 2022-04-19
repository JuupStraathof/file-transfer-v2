using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace file_transfer_v2
{
    public partial class FrmSelectProfile : Form
    {
        public XmlHandler xmlHandler = new XmlHandler();


        public FrmSelectProfile()
        {
            InitializeComponent();
        }

        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            int ProjectId = CmbSelectProfile.SelectedIndex;
            xmlHandler.CopyFiles(ProjectId);
            if (xmlHandler.fileHandler.ErrorMessage != null)
            {
                MessageBox.Show(xmlHandler.fileHandler.ErrorMessage.ToString());
            }
            BtnCopyFiles.Text = xmlHandler.fileHandler.ButtonText.ToString();
            timer1.Start();
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            Form ProfileManager = new ProfileManager(xmlHandler);

            ProfileManager.ShowDialog();
        }
        

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            xmlHandler.GetProjectElements(projectId);   
        }
        private void FrmSelectProfile_Load(object sender, EventArgs e)
        {  
            xmlHandler.GetNames();
            foreach (object obj in xmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId -1;
            }   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnCopyFiles.Text = "Copy files";
            timer1.Stop();
        }
    }
}
