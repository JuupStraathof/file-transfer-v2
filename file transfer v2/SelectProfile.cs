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
        public string xmlPath = "Database.xml";
        public Project project = new Project();
        public DbDocument document1;
        
        public FrmSelectProfile()
        {
            InitializeComponent();
        }
                   
        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            bool fileFlag = true;
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you can't copy this preset");
            }
            else
            {
                foreach (string s in project.ProjectFiles)
                {
                    //checks if files exists
                    if (!File.Exists(project.ProjectSourcePath + "/" + s))
                    {
                        fileFlag = false;
                    }
                }

                if (fileFlag == true)
                {
                    Directory.CreateDirectory(project.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString());
                    foreach (string s in project.ProjectFiles)
                    {
                        File.Copy(project.ProjectSourcePath + "/" + s, project.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd") + "/" + s, true);
                    }
                    MessageBox.Show("copying of files has been completed");
                }
                else
                {
                    if (fileFlag == true)
                    {
                        Directory.CreateDirectory(project.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString());
                        foreach (string s in project.ProjectFiles)
                        {   
                            File.Copy(project.ProjectSourcePath + "/" + s, project.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd") + "/" + s, true);
                        }
                        MessageBox.Show("copying of files has been completed");
                    }
                }
                if (fileFlag == false)
                {
                    MessageBox.Show("some files could not be found");
                }
            }
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            ProfileManager ProfileManagerForm = new ProfileManager(project, document1);
            ProfileManagerForm.ShowDialog();
            LoadData();
        }
        

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            int idirator = 0;
            project.ProjectFiles.Clear();
            //reading data from xml
            foreach (XElement projectElement in document1.document.Elements("project"))
            {
                if (idirator == projectId)
                {
                    foreach (var child in projectElement.Elements())
                    {
                        if (child.Name == "projectName")
                        {
                            project.ProjectName = child.Value;
                        }

                        if (child.Name == "projectSourcePath")
                        {
                            project.ProjectSourcePath = child.Value;
                        }

                        if (child.Name == "projectTargetPath")
                        {
                            project.ProjectTargetPath = child.Value;
                        }

                        if (child.Name == "projectFiles")
                        {
                            foreach (var decentand in child.Descendants())
                            {
                                if (decentand.Name == "File")
                                {
                                    project.ProjectFiles.Add(decentand.Value);
                                }
                            }
                        }
                    }
                }
                idirator++;
            }
        }
        private void LoadData()
        {
            CmbSelectProfile.Items.Clear();
            foreach (XElement projectElement in document1.document.Elements("projects").Elements("project"))
            {
                project.ProjectName = projectElement.Element("projectName").Value.ToString();
                project.ProjectSourcePath = projectElement.Element("projectSourcePath").Value.ToString();
                project.ProjectTargetPath = projectElement.Element("projectTargetPath").Value.ToString();
                
                foreach (var child in projectElement.Elements())
                {
                    foreach (var decentand in child.Descendants())
                    {
                        if (decentand.Name == "File")
                        {
                            project.ProjectFiles.Add(decentand.Value);
                        }
                    }
                }
                CmbSelectProfile.Items.Add(project.ProjectName.ToString());
            }
            int index = CmbSelectProfile.Items.Count;
            CmbSelectProfile.SelectedIndex = index - 1;
        }
        private void DatabaseExists()
        {
            if (!File.Exists(xmlPath))
            {
                XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var profile = new XElement("projects");

                xDoc.Add(profile);

                var project = new XElement("project");

                var projectName = new XElement("projectName");
                projectName.Value = "select a project";

                var source = new XElement("projectSourcePath");
                source.Value = "select a source path";

                var target = new XElement("projectTargetPath");
                target.Value = "select a target path";

                var projectfiles = new XElement("projectFiles");

                profile.Add(project);
                project.Add(projectName, source, target, projectfiles);

                for (int i = 1; i < 4; i++)
                {
                    var file = new XElement("File");
                    file.Value = "file" + i + ".txt".ToString();

                    projectfiles.Add(file);
                }

                xDoc.Save(xmlPath);

                MessageBox.Show("the xml file was not found, created a new one");
            }
            else
            {
                 DbDocument document = new DbDocument();
                 document1 = document;
            }
        }
     
        private void FrmSelectProfile_Load(object sender, EventArgs e)
        {
            DatabaseExists();
            LoadData();
        }
  
        private void BtnReloadDb_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
