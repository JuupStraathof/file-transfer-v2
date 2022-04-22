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
using Microsoft.WindowsAPICodePack.Dialogs;
using Ookii.Dialogs.WinForms;

namespace file_transfer_v2
{
    public partial class ProfileManager : Form
    {
        public XmlHandler _XmlHandler;
        public string xmlPath = "Database.xml";
        public ProfileManager(XmlHandler xmlHandler1)
        {
            InitializeComponent();
            _XmlHandler = xmlHandler1;
        }

        private void ProfileManager_Load(object sender, EventArgs e)
        {
            CmbSelectProfile.Items.Clear();
            foreach (object obj in _XmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }
        }
        
        private void BtnSelectSourcePath_Click(object sender, EventArgs e)
        {
            var openFolder = new VistaFolderBrowserDialog();
            openFolder.Description = "Select the source folder";
            openFolder.UseDescriptionForTitle = true;
            openFolder.SelectedPath = TxtSourcePath.Text + "/";

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                _XmlHandler.project.ProjectSourcePath = openFolder.SelectedPath.ToString();
               TxtSourcePath.Text = _XmlHandler.project.ProjectSourcePath;
            }
        }

        private void BtnSelectTargetPath_Click(object sender, EventArgs e)
        {
            var openFolder = new VistaFolderBrowserDialog();
            openFolder.Description = "Select the target folder";
            openFolder.UseDescriptionForTitle = true;
            openFolder.SelectedPath = TxtTargetPath.Text + "/";

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                _XmlHandler.project.ProjectTargetPath = openFolder.SelectedPath.ToString();
                TxtTargetPath.Text = _XmlHandler.project.ProjectTargetPath;
            }
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            _XmlHandler.project.ProjectSourcePath = TxtSourcePath.Text;
            if (_XmlHandler.project.ProjectSourcePath == null)
            {
                MessageBox.Show("no folder selected pick a source folder first");
            }
            else
            {
                using (OpenFileDialog selectFiles = new OpenFileDialog())
                {
                    selectFiles.InitialDirectory = _XmlHandler.project.ProjectSourcePath.ToString();
                    selectFiles.Multiselect = true;

                    if (selectFiles.ShowDialog() == DialogResult.OK)
                    {
                        _XmlHandler.project.ProjectFiles.Clear();
                        LsvSelectedFiles.Items.Clear();

                        foreach (object obj in selectFiles.SafeFileNames)
                        {
                            _XmlHandler.project.ProjectFiles.Add(obj.ToString());
                        }

                        foreach (string s in _XmlHandler.project.ProjectFiles)
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

        private void Timer1_Tick(object sender, EventArgs e)
        { 
            PbSaveProfile.Image = Image.FromFile("../../Images/SaveIcon.png");
            PbDeleteProfile.Image = Image.FromFile("../../Images/RedTrashCan.png");
            timer1.Stop();
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {  
            LsvSelectedFiles.Items.Clear();
            int projectId = CmbSelectProfile.SelectedIndex;
            _XmlHandler.SelectProject(projectId);


            foreach( string s in _XmlHandler.project.ProjectFiles)
            {
                string[] extentions = s.Split('.');
                var newRow = new string[] { extentions[0], "." + extentions[1] };
                var lvi = new ListViewItem(newRow);

                LsvSelectedFiles.Items.Add(lvi);
            }
         
            TxtProfileName.Text = _XmlHandler.project.ProjectName;
            TxtSourcePath.Text = _XmlHandler.project.ProjectSourcePath;
            TxtTargetPath.Text = _XmlHandler.project.ProjectTargetPath;
            TxtDateTimeFormat.Text = _XmlHandler.project.ProjectDateFormat;
        }

        private void PbDeleteProfile_Click(object sender, EventArgs e)
        {
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you cannot delete this project");
            }
            else
            {
                var MessageCaption = "Warning";
                var messageString = "Are you sure you want to delete the following project: " + CmbSelectProfile.SelectedItem.ToString() + "\n this action cannot be undone are you sure you want to continue?";
                var result = MessageBox.Show(messageString, MessageCaption, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Operation has been cancelled by user");
                }
                if (result == DialogResult.Yes)
                {
                    int projectId = CmbSelectProfile.SelectedIndex;
                    _XmlHandler.DeleteProfile(projectId);
                    _XmlHandler.GetNames();
                    CmbSelectProfile.Items.Clear();
                    foreach (object obj in _XmlHandler.ProfileNameList)
                    {
                        CmbSelectProfile.Items.Add(obj.ToString());
                        int CmbId = CmbSelectProfile.Items.Count;
                        CmbSelectProfile.SelectedIndex = CmbId - 1;
                    }
                    timer1.Start();
                    PbDeleteProfile.Image = Image.FromFile("../../Images/GreenCheckMark.png");
                    
                }
            }
        }

        private void PbAddNewProfile_Click(object sender, EventArgs e)
        {
            NewProfile newProfile = new NewProfile(_XmlHandler);

            newProfile.ShowDialog();
            CmbSelectProfile.Items.Clear();
            _XmlHandler.GetNames();
            foreach (object obj in _XmlHandler.ProfileNameList)
            {
                CmbSelectProfile.Items.Add(obj.ToString());
                int CmbId = CmbSelectProfile.Items.Count;
                CmbSelectProfile.SelectedIndex = CmbId - 1;
            }
        }

        private void PbSaveProfile_Click(object sender, EventArgs e)
        {
            if (TxtDateTimeFormat.Text != "")
            {
                int projectId = CmbSelectProfile.SelectedIndex;
                _XmlHandler.project.ProjectName = TxtProfileName.Text;
                _XmlHandler.project.ProjectSourcePath = TxtSourcePath.Text;
                _XmlHandler.project.ProjectTargetPath = TxtTargetPath.Text;
                _XmlHandler.project.ProjectDateFormat = TxtDateTimeFormat.Text;

                _XmlHandler.EditProfile(projectId);
                timer1.Start();
                //BtnEditProfile.Text = "saved changes";
                CmbSelectProfile.Items.Clear();
                _XmlHandler.GetNames();
                foreach (object obj in _XmlHandler.ProfileNameList)
                {
                    CmbSelectProfile.Items.Add(obj.ToString());
                    int CmbId = CmbSelectProfile.Items.Count;
                    CmbSelectProfile.SelectedIndex = CmbId - 1;
                }
                timer1.Start();
                PbSaveProfile.Image = Image.FromFile("../../Images/GreenCheckMark.png");
            }
            else
            {
                MessageBox.Show("No dateTime format found");
            }
        }

        private void TxtProfileName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}