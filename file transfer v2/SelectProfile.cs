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
            _xmlHandler.fileHandler.CopyFiles(ProjectId, _xmlHandler);

            if (_xmlHandler.fileProperties.ErrorMessage != null)
            {  
                MessageBox.Show(_xmlHandler.fileProperties.ErrorMessage.ToString());
            }
            else
            {
                BtnCopyFiles.Text = "Copying completed";
            }

            Timer1.Start();
            _xmlHandler.project.LastUsedProject = CmbSelectProfile.SelectedIndex.ToString();
            _xmlHandler.SetLastSelectedProfile();
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
            }

            if (int.Parse(_xmlHandler.project.LastUsedProject) <= CmbSelectProfile.Items.Count)
            {
                CmbSelectProfile.SelectedIndex = int.Parse(_xmlHandler.project.LastUsedProject);
            }
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            _xmlHandler.GetProjectElements(projectId);   
        }
        private void FrmSelectProfile_Load(object sender, EventArgs e)
        {
            string DBlocation = "/FileTransferResources/Database.xml";
            //_xmlHandler.XmlPath = Environment.GetFolderPath(Environment.SpecialFolder.System).ToString() + DBlocation;
            _xmlHandler.XmlPath = DBlocation;
            _xmlHandler.DatabaseExists();
            _xmlHandler.LoadDb();
            _xmlHandler.GetNames();
            _xmlHandler.GetLastSelectedProfile();

            foreach (object obj in _xmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
            }

            if (int.Parse(_xmlHandler.project.LastUsedProject) <= CmbSelectProfile.Items.Count)
            {
                CmbSelectProfile.SelectedIndex = int.Parse(_xmlHandler.project.LastUsedProject);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            BtnCopyFiles.Text = "Copy files";
            Timer1.Stop();
        }
    }
}
