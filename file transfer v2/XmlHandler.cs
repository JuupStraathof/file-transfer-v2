using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace file_transfer_v2
{
    public class XmlHandler
    {
   
        public Project project = new Project();
        public List<string> ProfileNameList = new List<string>();
        public XDocument document;
        private string XmlPath = "Database.xml";
        public FileProperties fileProperties = new FileProperties();
        public List<string> FileLists = new List<string>();
        //private string FolderDate;
        public FileHandler fileHandler = new FileHandler();

        public void GetNames()
        {
            ProfileNameList.Clear();
            foreach (XElement projects in document.Elements("Projects"))
            {
                foreach (XElement projectElements in projects.Elements("Project"))
                {
                    foreach (XElement ProjectSubElements in projectElements.Descendants())
                    {
                        if (ProjectSubElements.Name == "ProjectName")
                        {
                            ProfileNameList.Add(ProjectSubElements.Value);
                        }
                    }
                }
            }
        }
        public void LoadDb()
        {
            document = XDocument.Load(XmlPath);
        }

        public void GetProjectElements(int ProjectId)
        {
            project.ProjectFiles.Clear();
            int i = 0;
            foreach (XElement projects in document.Elements("Projects"))
            {
                foreach (XElement projectElements in projects.Elements("Project"))
                {
                    if (i == ProjectId)
                    {
                        foreach (XElement ProjectSubElements in projectElements.Descendants())
                        {
                            if (ProjectSubElements.Name == "ProjectName")
                            {
                                project.ProjectName = ProjectSubElements.Value;
                            }

                            if (ProjectSubElements.Name == "ProjectSourcePath")
                            {
                                project.ProjectSourcePath = ProjectSubElements.Value;
                            }

                            if (ProjectSubElements.Name == "ProjectTargetPath")
                            {
                                project.ProjectTargetPath = ProjectSubElements.Value;
                            }

                            if (ProjectSubElements.Name == "ProjectFiles")
                            {
                                foreach (XElement fileElements in ProjectSubElements.Descendants())
                                {
                                   // Console.WriteLine(fileElements.Value.ToString());
                                    project.ProjectFiles.Add(fileElements.Value);
                                }
                            }
                        }
                    }
                    i++;
                }
            }
        }

        public void DatabaseExists()
        {
            if (!File.Exists(XmlPath))
            {
                XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var profile = new XElement("Projects");

                xDoc.Add(profile);

                var project = new XElement("Project");

                var projectName = new XElement("ProjectName");
                projectName.Value = "Select a project";

                var source = new XElement("ProjectSourcePath");
                source.Value = "Select a source path";

                var target = new XElement("ProjectTargetPath");
                target.Value = "Select a target path";

                var projectfiles = new XElement("ProjectFiles");

                profile.Add(project);
                project.Add(projectName, source, target, projectfiles);

                for (int i = 1; i < 4; i++)
                {
                    var file = new XElement("File");
                    file.Value = "file" + i + ".txt".ToString();

                    projectfiles.Add(file);
                }

                xDoc.Save(XmlPath);

                fileProperties.ErrorMessage = "The xml file was not found, created a new one";
            }
        }

        public void SelectProject(int projectId)
        {
            int projectCount = 0;

            project.ProjectFiles.Clear();
            //reading data from xml

            foreach (XElement projectElement in XElement.Load(XmlPath).Elements("Project"))
            {
                if (projectCount == projectId)
                {
                    foreach (var child in projectElement.Elements())
                    {
                        if (child.Name == "ProjectName")
                        {
                            project.ProjectName = child.Value;
                        }

                        if (child.Name == "ProjectSourcePath")
                        {
                            project.ProjectSourcePath = child.Value;
                        }

                        if (child.Name == "ProjectTargetPath")
                        {
                            project.ProjectTargetPath = child.Value;
                        }

                        if (child.Name == "DateTimeFormat")
                        {
                            project.ProjectDateFormat = child.Value;
                        }
                        foreach (var decentand in child.Descendants())
                        {
                            if (decentand.Name == "File")
                            {
                                //adding files to listview
                                //splitting the file names on the . so we can seperate them into 2 colums
                               project.ProjectFiles.Add(decentand.Value);
                            }
                        }
                    }
                }
                projectCount++;
            }
        }

        public void DeleteProfile(int projectId)
        {
            if (projectId == 0)
            {
                fileProperties.ErrorMessage = "You cannot delete this project";
            }
            else
            {
                
                var projectsElement = document.Elements("Projects");
                int projectcount = 0;
                foreach (XElement projectElement in projectsElement.Elements("Project"))
                {
                    if (projectcount == projectId)
                    {
                        projectElement.Remove();
                    }
                    projectcount++;
                }
                document.Save(XmlPath);
                fileProperties.ButtonText = "Profile deleted";
            }
        }

        public void EditProfile(int ProjectId)
        {
            fileProperties.ButtonText = null;
            fileProperties.ErrorMessage = null;
            bool fileFlag = true;
            if (ProjectId == 0)
            {
                 fileProperties.ErrorMessage = "You cannot edit this profile";
            }
            else
            {
                if (Directory.Exists(project.ProjectSourcePath.ToString()) && Directory.Exists(project.ProjectTargetPath.ToString()))
                {
                    foreach (string s in project.ProjectFiles)
                    {
                        if (!File.Exists(project.ProjectSourcePath.ToString() + "/" + s))
                        {
                            fileFlag = false;
                        }
                    }

                    if (fileFlag == false)
                    {
                        fileProperties.ErrorMessage = "Some or all files could not be found";
                    }
                    else
                    {
                        var projectsElement = document.Elements();
                        var projects = projectsElement.Elements();

                        int projectCount = 0;
                        foreach (XElement projectElement in projects)
                        {
                            if (projectCount == ProjectId)
                            {
                                foreach (XElement projectElements in projectElement.Descendants())
                                {
                                    if (projectElements.Name == "ProjectName")
                                    {
                                        projectElements.Value = project.ProjectName;
                                    }

                                    if (projectElements.Name == "ProjectSourcePath")
                                    {
                                        projectElements.Value = project.ProjectSourcePath;
                                    }

                                    if (projectElements.Name == "ProjectTargetPath")
                                    {
                                        projectElements.Value = project.ProjectTargetPath;
                                    }

                                    if (projectElements.Name == "ProjectFiles")
                                    {
                                        projectElements.RemoveNodes();

                                        foreach (object obj in project.ProjectFiles)
                                        {
                                            projectElements.Add(new XElement("File", obj.ToString()));
                                        }
                                    }

                                    if (projectElements.Name == "DateTimeFormat")
                                    {
                                        projectElements.Value = project.ProjectDateFormat;
                                    }
                                }
                            }
                            projectCount++;
                        }

                        document.Save(XmlPath);
                        
                        fileProperties.ButtonText = "Changes have been saved";
                    }
                }

                else
                {
                    fileProperties.ErrorMessage = "One or both given paths do not exist";
                }
            }
        }

        public void CreateNewProfile()
        {
            //loading document
            XDocument xdoc = document;

            //creating new elements
            var projects = new XElement("Project");
            var projectName = new XElement("ProjectName");
            var projectSourcePath = new XElement("ProjectSourcePath");
            var projectTargetPath = new XElement("ProjectTargetPath");
            var projectFiles = new XElement("ProjectFiles");
            var ProjectDateFormat = new XElement("DateTimeFormat");

            //giving values to elements
            projectName.Value = project.ProjectName;

            //adding elements to file
            xdoc.Element("Projects").Add(projects);
            projects.Add(projectName, projectSourcePath, projectTargetPath, projectFiles,ProjectDateFormat);

            xdoc.Save(XmlPath);
        }
    }
} 


