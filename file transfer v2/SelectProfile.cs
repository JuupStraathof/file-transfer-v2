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
        public XmlHandler _xmlHandler = new XmlHandler();
        


        public FrmSelectProfile()
        {
            InitializeComponent();
        }

        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            
            int ProjectId = CmbSelectProfile.SelectedIndex;
            _xmlHandler.project.ProjectFiles.Clear();
            _xmlHandler.GetProjectElements(ProjectId);
            Console.WriteLine(_xmlHandler.project.ProjectSourcePath.ToString());
            

            _xmlHandler.fileHandler.CopyFiles(ProjectId ,_xmlHandler);
            if (_xmlHandler.fileProperties.ErrorMessage != null)
            {
                MessageBox.Show(_xmlHandler.fileProperties.ErrorMessage.ToString());
            }
            //BtnCopyFiles.Text = _xmlHandler.fileHandler.ButtonText.ToString();
            timer1.Start(); 
           
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            Form ProfileManager = new ProfileManager(_xmlHandler);

            ProfileManager.ShowDialog();
            CmbSelectProfile.Items.Clear();
            _xmlHandler.GetNames();
            foreach (object obj in _xmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }
        }
        

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            _xmlHandler.GetProjectElements(projectId);   
        }
        private void FrmSelectProfile_Load(object sender, EventArgs e)
        {
            _xmlHandler.DatabaseExists();
            _xmlHandler.LoadDb();
            _xmlHandler.GetNames();
            foreach (object obj in _xmlHandler.ProfileNameList)
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
