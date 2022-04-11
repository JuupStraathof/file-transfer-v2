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
        public string xmlPath = "Database.xml";
        private void ProfileManager_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            int projectCount = 0;
            _fileInfo.ProjectFiles.Clear();
            LsvSelectedFiles.Items.Clear();
            //reading data from xml
            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
            {
                if (projectCount == projectId)
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
                                //adding files to listview
                                //splitting the file names on the . so we can seperate them into 2 colums
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
                projectCount++;
            }
        }


        private void LoadData()
        {
            //clearing file list and combobox to prevent double data writing
            _fileInfo.ProjectFiles.Clear();
            CmbSelectProfile.Items.Clear();

            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
            {
                //filling the properties with the values
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
            bool fileFlag = true;
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you cannot edit this profile");
            }
            else
            {
                if (Directory.Exists(TxtSourcePath.Text) && Directory.Exists(TxtTargetPath.Text))
                {
                    foreach (string s in _fileInfo.ProjectFiles)
                    {
                        if (!File.Exists(TxtSourcePath.Text + "/" + s))
                        {
                            fileFlag = false;
                        }
                    }

                    if (fileFlag == false)
                    {
                        MessageBox.Show("some or all files could not be found");
                    }
                    else
                    {
                        var doc = XDocument.Load(xmlPath);
                        var projectsElement = doc.FirstNode as XElement;
                        var projects = projectsElement.Elements();

                        int projectCount = 0;
                        foreach (XElement projectElement in projects)
                        {
                            if (projectCount == CmbSelectProfile.SelectedIndex)
                            {
                                foreach (XElement projectElements in projectElement.Descendants())
                                {
                                    if (projectElements.Name == "projectName")
                                    {
                                        projectElements.Value = TxtProfileName.Text;
                                    }

                                    if (projectElements.Name == "projectSourcePath")
                                    {
                                        projectElements.Value = TxtSourcePath.Text;
                                    }

                                    if (projectElements.Name == "projectTargetPath")
                                    {
                                        projectElements.Value = TxtTargetPath.Text;
                                    }

                                    if (projectElements.Name == "projectFiles")
                                    {
                                        projectElements.RemoveNodes();

                                        foreach (object obj in _fileInfo.ProjectFiles)
                                        {
                                            projectElements.Add(new XElement("File", obj.ToString()));
                                        }
                                    }
                                }
                            }
                            projectCount++;
                        }

                        doc.Save(xmlPath);
                        MessageBox.Show("the profile has been changed");
                        LoadData();
                    }
                }

                else
                {
                    MessageBox.Show("one or both given paths do not exist");
                }
            }
        }

        private void BtnNewProfile_Click(object sender, EventArgs e)
        {
            bool fileFlag = true;
            foreach (string s in _fileInfo.ProjectFiles)
            {
                if (!File.Exists(TxtSourcePath.Text + "/" + s))
                {
                    fileFlag = false;
                }
            }

            if (fileFlag == false)
            {
                MessageBox.Show("some or all files could not be found");
            }

            else
            {
                if (Directory.Exists(TxtSourcePath.Text) && Directory.Exists(TxtTargetPath.Text))
                {
                    //loading document
                    XDocument xdoc = XDocument.Load(xmlPath);

                    //creating new elements
                    var projects = new XElement("project");
                    var projectName = new XElement("projectName");
                    var projectSourcePath = new XElement("projectSourcePath");
                    var projectTargetPath = new XElement("projectTargetPath");
                    var projectFiles = new XElement("projectFiles");

                    //giving values to elements
                    projectName.Value = TxtProfileName.Text;
                    projectSourcePath.Value = _fileInfo.ProjectSourcePath.ToString();
                    projectTargetPath.Value = _fileInfo.ProjectTargetPath.ToString();

                    //adding elements to file
                    xdoc.Element("projects").Add(projects);
                    projects.Add(projectName, projectSourcePath, projectTargetPath, projectFiles);
                    foreach (object elements in _fileInfo.ProjectFiles)
                    {
                        //creating new child element for the individual files
                        //for loop is used to prevent wrong data writing
                        var projectFile = new XElement("File");
                        projectFile.Value = elements.ToString();
                        projectFiles.Add(projectFile);
                    }
                    xdoc.Save(xmlPath);
                    MessageBox.Show("new profile has been added with the following name: " + projectName.Value);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("one or both given paths do not exist");
                }
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you cannot delete this project");
            }
            else
            {
                var MessageCaption = "warning";
                var messageString = "are you sure you want to delete the following project: " + CmbSelectProfile.SelectedItem.ToString() + "\n this action cannot be undone are you sure you want to continue?";
                var result = MessageBox.Show(messageString, MessageCaption, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("the deletion has been cancelled");
                }
                if (result == DialogResult.Yes)
                {
                    var doc = XDocument.Load(xmlPath);
                    var projectsElement = doc.Elements("projects");
                    int projectcount = 0;
                    foreach (XElement projectElement in projectsElement.Elements("project"))
                    {
                        if (projectcount == CmbSelectProfile.SelectedIndex)
                        {
                            
                            projectElement.Remove();
                        }
                        projectcount++;
                    }
                    doc.Save(xmlPath);
                    MessageBox.Show("the project has been deleted");
                    LoadData();
                }
            }
        }
    }
}