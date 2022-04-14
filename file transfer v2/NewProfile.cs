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
    public partial class NewProfile : Form
    {
        private Project project;
        private XDocument xdocument;

        public NewProfile(Project project1, XDocument dbDocument)
        {
            InitializeComponent();
            project = project1;
            xdocument = dbDocument;
        }
        //projects project = new projects();
        private void BtnSourcePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog sourceFileBrowser = new FolderBrowserDialog() { Description = "select the debug folder" })
            {
                if (sourceFileBrowser.ShowDialog() == DialogResult.OK)
                {
                    project.ProjectSourcePath = sourceFileBrowser.SelectedPath.ToString();
                    txtSourcePath.Text = project.ProjectSourcePath.ToString();
                }
            }
        }

        private void BtnTargetPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog targetFolderBrowser = new FolderBrowserDialog() { Description = "select the target folder" })
            {
                if (targetFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtTargetPath.Text = targetFolderBrowser.SelectedPath.ToString();
                    project.ProjectTargetPath = targetFolderBrowser.SelectedPath.ToString();
                }
            }
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            project.ProjectSourcePath = txtSourcePath.Text;
            if (project.ProjectSourcePath == null)
            {
                MessageBox.Show("no folder selected pick a source folder first");
            }
            else
            {
                using (OpenFileDialog selectFiles = new OpenFileDialog())
                {
                    selectFiles.InitialDirectory = project.ProjectSourcePath.ToString();
                    selectFiles.Multiselect = true;

                    if (selectFiles.ShowDialog() == DialogResult.OK)
                    {
                        project.ProjectFiles.Clear();
                        LsvSelectedFiles.Items.Clear();

                        foreach (object obj in selectFiles.SafeFileNames)
                        {
                            project.ProjectFiles.Add(obj.ToString());
                        }

                        foreach (string s in project.ProjectFiles)
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

        private void BtnCreateProfile_Click(object sender, EventArgs e)
        {
            bool fileFlag = true;
            foreach (string s in project.ProjectFiles)
            {
                if (!File.Exists(txtSourcePath.Text + "/" + s))
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
                if (Directory.Exists(txtSourcePath.Text) && Directory.Exists(txtTargetPath.Text))
                {
                    //creating new elements
                    var projects = new XElement("project");
                    var projectName = new XElement("projectName");
                    var projectSourcePath = new XElement("projectSourcePath");
                    var projectTargetPath = new XElement("projectTargetPath");
                    var projectFiles = new XElement("projectFiles");

                    //giving values to elements
                    projectName.Value = TxtProjectName.Text;
                    projectSourcePath.Value = project.ProjectSourcePath.ToString();
                    projectTargetPath.Value = project.ProjectTargetPath.ToString();

                    //adding elements to file
                    xdocument.Element("projects").Add(projects);
                    projects.Add(projectName, projectSourcePath, projectTargetPath, projectFiles);
                    foreach (object elements in project.ProjectFiles)
                    {
                        //creating new child element for the individual files
                        //for loop is used to prevent wrong data writing
                        var projectFile = new XElement("File");
                        projectFile.Value = elements.ToString();
                        projectFiles.Add(projectFile);
                    }

                    xdocument.Save("Database.xml");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("one or both given paths do not exist");
                }
            }
        }

        private void NewProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
