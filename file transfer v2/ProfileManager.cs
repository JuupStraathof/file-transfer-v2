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
        private FileInfo _fileInfo;
        public ProfileManager()
        {
            InitializeComponent();
            _fileInfo = new FileInfo();
             
        }
        List<FileInfo> lstFileInfo = new List<FileInfo>();

        private void ProfileManager_Load(object sender, EventArgs e)
        {   
            LoadData();
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            int idirator = 0;
            _fileInfo.ProjectFiles.Clear();
            LsvSelectedFiles.Items.Clear();
            //reading data from xml
            foreach (XElement projectElement in XElement.Load("..\\..\\..\\Database.xml").Elements("project"))
            {
                if (idirator == projectId)
                {
                    foreach (var child in projectElement.Elements())
                    {
                        if (child.Name == "projectName")
                        {
                            _fileInfo.ProjectName = child.Value;
                            TxtProfileName.Text = child.Value;
                        }

                        if (child.Name == "projectSourcePath")
                        {
                            _fileInfo.ProjectSourcePath = child.Value;
                            TxtSourcePath.Text = child.Value;
                        }

                        if (child.Name == "projectTargetPath")
                        {
                            _fileInfo.ProjectTargetPath = child.Value;
                            TxtTargetPath.Text = child.Value;
                        }


                        foreach (var decentand in child.Descendants())
                        {
                            if (decentand.Name == "File")
                            {
                                _fileInfo.ProjectFiles.Add(decentand.Value);
                                string s = decentand.Value;
                                string[] extentions = s.Split('.');
                                var newRow = new string[] { extentions[0], "." + extentions[1] };
                                var lvi = new ListViewItem(newRow);

                                LsvSelectedFiles.Items.Add(lvi);
                            }
                        }
                    }

                }
                idirator++;
            }
        }


        private void LoadData()
        {
            _fileInfo.ProjectFiles.Clear();
            foreach (XElement projectElement in XElement.Load("..\\..\\..\\Database.xml").Elements("project"))
            {
                _fileInfo.ProjectName = projectElement.Element("projectName").Value.ToString();
                _fileInfo.ProjectSourcePath = projectElement.Element("projectSourcePath").Value.ToString();
                _fileInfo.ProjectTargetPath = projectElement.Element("projectTargetPath").Value.ToString();


                foreach (var child in projectElement.Elements())
                {
                    foreach (var decentand in child.Descendants())
                    {
                        if (decentand.Name == "File")
                        {
                            _fileInfo.ProjectFiles.Add(decentand.Value);
                        }
                    }
                }
                CmbSelectProfile.Items.Add(_fileInfo.ProjectName.ToString());

                lstFileInfo.Add(_fileInfo);
            }
            CmbSelectProfile.SelectedIndex = 0;
        }
        public class FileInfo
        {
            // class for making objects to read and write to xml file
            public string ProjectName { get; set; }
            public List<string> ProjectFiles = new List<string>();
            public string ProjectSourcePath { get; set; }
            public string ProjectTargetPath { get; set; }
        }

        private void BtnSelectSourcePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog sourceFileBrowser = new FolderBrowserDialog() { Description = "select the debug folder" })
            {
                if (sourceFileBrowser.ShowDialog() == DialogResult.OK)
                {
                    _fileInfo.ProjectSourcePath = sourceFileBrowser.SelectedPath.ToString();
                    TxtSourcePath.Text = _fileInfo.ProjectSourcePath.ToString();
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
                    _fileInfo.ProjectTargetPath = targetFolderBrowser.SelectedPath.ToString();
                }
            }
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            _fileInfo.ProjectSourcePath = TxtSourcePath.Text;
            if (_fileInfo.ProjectSourcePath == null)
            {
                MessageBox.Show("no folder selected pick a source folder first");
            }
            else
            {
                using (OpenFileDialog selectFiles = new OpenFileDialog())
                {
                    selectFiles.InitialDirectory = _fileInfo.ProjectSourcePath.ToString();
                    selectFiles.Multiselect = true;

                    if (selectFiles.ShowDialog() == DialogResult.OK)
                    {
                        _fileInfo.ProjectFiles.Clear();
                        LsvSelectedFiles.Items.Clear();

                        foreach (object obj in selectFiles.SafeFileNames)
                        {
                            _fileInfo.ProjectFiles.Add(obj.ToString());
                        }

                        foreach (string s in _fileInfo.ProjectFiles)
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
            _fileInfo.ProjectFiles.Clear();
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you cannot edit this profile");
            }
            else
            {

                var xlist = XElement.Load("..\\..\\..\\Database.xml").Elements("project").ToList();
                var result = 


                foreach (XElement projectElement in XElement.Load("..\\..\\..\\Database.xml").Elements("project"))
                {
                    foreach (var child in projectElement.Elements())
                    {
                        if (child.Name == "projectName")
                        {
                            if (child.Value == CmbSelectProfile.SelectedItem.ToString())
                            {
                                _fileInfo.ProjectName = TxtProfileName.Text;
                                _fileInfo.ProjectSourcePath = TxtSourcePath.Text;
                                _fileInfo.ProjectTargetPath = TxtTargetPath.Text;

                                foreach (object s in _fileInfo.ProjectFiles)
                                {
                                    MessageBox.Show(s.ToString());
                                }
                                foreach (var decentand in child.Descendants())
                                {
                                    
                                    foreach(var childDecentand in decentand.Descendants())
                                    {
                                        MessageBox.Show(childDecentand.Value.ToString());
                                        if (childDecentand.Name == "Files")
                                        {
                                            _fileInfo.ProjectFiles.Add(decentand.Value);
                                        }
                                    }
                                }
                            }
                        }
                        
                        
                    }
                }

                //editing profile in the xml file            
            }
        }

        private void BtnNewProfile_Click(object sender, EventArgs e)
        {
            //adding new profile to xml file
        }
    }
}