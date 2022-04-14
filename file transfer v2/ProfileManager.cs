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
        Project project1;
        DbDocument xdocument;
        public ProfileManager(Project project, DbDocument document)
        {
            InitializeComponent();
              project1 = project;
            xdocument = document;
        }
        public string xmlPath = "Database.xml";
        
        private void ProfileManager_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        { 
            int projectId = CmbSelectProfile.SelectedIndex;
            int projectCount = 0;

            project1.ProjectFiles.Clear();  
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
                            project1.ProjectName = child.Value;
                            TxtProfileName.Text = child.Value;
                        }

                        if (child.Name == "projectSourcePath")
                        {
                            project1.ProjectSourcePath = child.Value;
                            TxtSourcePath.Text = child.Value;
                        }

                        if (child.Name == "projectTargetPath")
                        {
                            project1.ProjectTargetPath = child.Value;
                            TxtTargetPath.Text = child.Value;
                        }

                        foreach (var decentand in child.Descendants())
                        {
                            if (decentand.Name == "File")
                            {
                                //adding files to listview
                                //splitting the file names on the . so we can seperate them into 2 colums
                                project1.ProjectFiles.Add(decentand.Value);
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
            project1.ProjectFiles.Clear();
            CmbSelectProfile.Items.Clear();

            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
            {
                //filling the properties with the values
                project1.ProjectName = projectElement.Element("projectName").Value.ToString();
                project1.ProjectSourcePath = projectElement.Element("projectSourcePath").Value.ToString();
                project1.ProjectTargetPath = projectElement.Element("projectTargetPath").Value.ToString();

                foreach (var child in projectElement.Elements())
                {
                    foreach (var decentand in child.Descendants())
                    {
                        if (decentand.Name == "File")
                        {
                            project1.ProjectFiles.Add(decentand.Value);
                        }
                    }
                }
                CmbSelectProfile.Items.Add(project1.ProjectName.ToString());
            }
            int index = 0;
            index = CmbSelectProfile.Items.Count;
            CmbSelectProfile.SelectedIndex = index - 1;
        }

        private void BtnSelectSourcePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog sourceFileBrowser = new FolderBrowserDialog() { Description = "select the debug folder" })
            {
                if (sourceFileBrowser.ShowDialog() == DialogResult.OK)
                {
                    project1.ProjectSourcePath = sourceFileBrowser.SelectedPath.ToString();
                    TxtSourcePath.Text = project1.ProjectSourcePath.ToString();
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
                    project1.ProjectTargetPath = targetFolderBrowser.SelectedPath.ToString();
                }
            }
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            project1.ProjectSourcePath = TxtSourcePath.Text;
            if (project1.ProjectSourcePath == null)
            {
                MessageBox.Show("no folder selected pick a source folder first");
            }
            else
            {
                using (OpenFileDialog selectFiles = new OpenFileDialog())
                {
                    selectFiles.InitialDirectory = project1.ProjectSourcePath.ToString();
                    selectFiles.Multiselect = true;

                    if (selectFiles.ShowDialog() == DialogResult.OK)
                    {
                        project1.ProjectFiles.Clear();
                        LsvSelectedFiles.Items.Clear();

                        foreach (object obj in selectFiles.SafeFileNames)
                        {
                            project1.ProjectFiles.Add(obj.ToString());
                        }

                        foreach (string s in project1.ProjectFiles)
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
                    foreach (string s in project1.ProjectFiles)
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

                                        foreach (object obj in project1.ProjectFiles)
                                        {
                                            projectElements.Add(new XElement("File", obj.ToString()));
                                        }
                                    }
                                }
                            }
                            projectCount++;
                        }

                        doc.Save(xmlPath);
                        LoadData();
                        BtnEditProfile.Text = "changes have been saved";
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
            Form frmNewProfile = new NewProfile(project1, xdocument.document);

            frmNewProfile.ShowDialog();
            LoadData();
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you cannot delete this project");
            }
            else
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
                LoadData();
                btnDeleteProject.Text = "profile deleted";
                
            }
        }
    }
}