using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace file_transfer_v2
{
    public partial class ProfileManager : Form
    {
         private XmlHandler XmlHandler;
        public ProfileManager(XmlHandler xmlHandler1)
        {
            InitializeComponent();
            XmlHandler = xmlHandler1;
        }
        public string xmlPath = "Database.xml";
        
        private void ProfileManager_Load(object sender, EventArgs e)
        { 
            foreach (object obj in XmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }
        }
        
        private void BtnSelectSourcePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog sourceFileBrowser = new FolderBrowserDialog() { Description = "select the debug folder" })
            {
                if (sourceFileBrowser.ShowDialog() == DialogResult.OK)
                {
                    XmlHandler.project.ProjectSourcePath = sourceFileBrowser.SelectedPath.ToString();
                    TxtSourcePath.Text = XmlHandler.project.ProjectSourcePath.ToString();
                }
            }
        }

        private void BtnSelectTargetPath_Click(object sender, EventArgs e)
        { 
            using (FolderBrowserDialog targetFolderBrowser = new FolderBrowserDialog() { Description = "select the target folder" })
            {
                if (targetFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    TxtTargetPath.Text = targetFolderBrowser.SelectedPath.ToString();
                    XmlHandler.project.ProjectTargetPath = targetFolderBrowser.SelectedPath.ToString();
                }
            }
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            XmlHandler.project.ProjectSourcePath = TxtSourcePath.Text;
            if (XmlHandler.project.ProjectSourcePath == null)
            {
                MessageBox.Show("no folder selected pick a source folder first");
            }
            else
            {
                using (OpenFileDialog selectFiles = new OpenFileDialog())
                {
                    selectFiles.InitialDirectory = XmlHandler.project.ProjectSourcePath.ToString();
                    selectFiles.Multiselect = true;

                    if (selectFiles.ShowDialog() == DialogResult.OK)
                    {
                        XmlHandler.project.ProjectFiles.Clear();
                        LsvSelectedFiles.Items.Clear();

                        foreach (object obj in selectFiles.SafeFileNames)
                        {
                            XmlHandler.project.ProjectFiles.Add(obj.ToString());
                        }

                        foreach (string s in XmlHandler.project.ProjectFiles)
                        {
                            string[] extentions = s.Split('.');
                            var newRow = new string[] { extentions[0], "." + extentions[1] };
                            var lvi = new ListViewItem(newRow);

                            LsvSelectedFiles.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            XmlHandler.project.ProjectName = TxtProfileName.Text;
            XmlHandler.project.ProjectSourcePath = TxtSourcePath.Text;
            XmlHandler.project.ProjectTargetPath = TxtTargetPath.Text;

            XmlHandler.EditProfile(projectId);
            timer1.Start();
            BtnEditProfile.Text = "saved changes";
        }

        private void BtnNewProfile_Click(object sender, EventArgs e)
        {
            NewProfile newProfile = new NewProfile(XmlHandler);

            newProfile.ShowDialog();
            CmbSelectProfile.Items.Clear();
            XmlHandler.GetNames();
            foreach (object obj in XmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }

        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            XmlHandler.DeleteProfile(projectId);
            XmlHandler.GetNames();
            CmbSelectProfile.Items.Clear();
            foreach (object obj in XmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }
            timer1.Start();
            btnDeleteProject.Text = "Deleted project";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnEditProfile.Text = "Save changes";
            btnDeleteProject.Text = "Delete project";
            timer1.Stop();
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {  
            LsvSelectedFiles.Items.Clear();
            int projectId = CmbSelectProfile.SelectedIndex;
            XmlHandler.SelectProject(projectId);

            foreach( string s in XmlHandler.project.ProjectFiles)
            {
                string[] extentions = s.Split('.');
                var newRow = new string[] { extentions[0], "." + extentions[1] };
                var lvi = new ListViewItem(newRow);

                LsvSelectedFiles.Items.Add(lvi);
            }
         
            TxtProfileName.Text = XmlHandler.project.ProjectName;
            TxtSourcePath.Text = XmlHandler.project.ProjectSourcePath;
            TxtTargetPath.Text = XmlHandler.project.ProjectTargetPath;
        }
    }
}