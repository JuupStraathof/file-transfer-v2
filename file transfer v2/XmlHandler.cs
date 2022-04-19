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
        public XDocument document = XDocument.Load("Database.xml");
        private string xmlPath = "Database.xml";
        public FileHandler fileHandler = new FileHandler();
        public List<string> FileLists = new List<string>();


        public void GetNames()
        {
            ProfileNameList.Clear();
            foreach (XElement projects in document.Elements("projects"))
            {
                foreach (XElement projectElements in projects.Elements("project"))
                {
                    foreach (XElement ProjectSubElements in projectElements.Descendants())
                    {
                        if (ProjectSubElements.Name == "projectName")
                        {
                            ProfileNameList.Add(ProjectSubElements.Value);
                        }
                    }
                }
            }

        }
        public void GetProjectElements(int ProjectId)
        {
            project.ProjectFiles.Clear();
            int i = 0;
            foreach (XElement projects in document.Elements("projects"))
            {
                foreach (XElement projectElements in projects.Elements("project"))
                {
                    if (i == ProjectId)
                    {
                        foreach (XElement ProjectSubElements in projectElements.Descendants())
                        {
                            if (ProjectSubElements.Name == "projectName")
                            {
                                project.ProjectName = projectElements.Value;
                            }

                            if (projectElements.Name == "projectSourcePath")
                            {
                                project.ProjectSourcePath = projectElements.Value;
                            }

                            if (projectElements.Name == "projectTargetPath")
                            {
                                project.ProjectTargetPath = projectElements.Value;
                            }

                            if (projectElements.Name == "projectFiles")
                            {
                                foreach (XElement fileElements in projectElements.Descendants())
                                {
                                    project.ProjectFiles.Add(fileElements.Value);
                                }
                            }
                        }
                    }
                    i++;
                }
            }
        }

        public void CopyFiles(int ProjectId)
        {
            bool fileFlag = true;
            if (ProjectId == 0)
            {
                fileHandler.ErrorMessage = "you can't copy this preset";
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
                    fileHandler.ButtonText = "copying of the files has been completed";
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
                        fileHandler.ButtonText = "copying of the files has been completed";
                    }
                }
                if (fileFlag == false)
                {
                    fileHandler.ErrorMessage = "some files could not be found";
                }
            }
        }

        public void DatabaseExists()
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

                fileHandler.ErrorMessage = "the xml file was not found, created a new one";
            }
        }

        public void SelectProject(int projectId)
        {
            int projectCount = 0;

            project.ProjectFiles.Clear();
            //reading data from xml

            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
            {
                if (projectCount == projectId)
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
                fileHandler.ErrorMessage = "you cannot delete this project";
            }
            else
            {
                
                var projectsElement = document.Elements("projects");
                int projectcount = 0;
                foreach (XElement projectElement in projectsElement.Elements("project"))
                {
                    if (projectcount == projectId)
                    {
                        projectElement.Remove();
                    }
                    projectcount++;
                }
                document.Save(xmlPath);
                fileHandler.ButtonText = "profile deleted";
            }
        }


        public void EditProfile(int ProjectId)
        {
            fileHandler.ButtonText = null;
            fileHandler.ErrorMessage = null;
            bool fileFlag = true;
            if (ProjectId == 0)
            {
                 fileHandler.ErrorMessage = "you cannot edit this profile";
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
                        fileHandler.ErrorMessage = "some or all files could not be found";
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
                                    if (projectElements.Name == "projectName")
                                    {
                                        projectElements.Value = project.ProjectName;
                                    }

                                    if (projectElements.Name == "projectSourcePath")
                                    {
                                        projectElements.Value = project.ProjectSourcePath;
                                    }

                                    if (projectElements.Name == "projectTargetPath")
                                    {
                                        projectElements.Value = project.ProjectTargetPath;
                                    }

                                    if (projectElements.Name == "projectFiles")
                                    {
                                        projectElements.RemoveNodes();

                                        foreach (object obj in project.ProjectFiles)
                                        {
                                            projectElements.Add(new XElement("File", obj.ToString()));
                                        }
                                    }
                                }
                            }
                            projectCount++;
                        }

                        document.Save(xmlPath);
                        
                        fileHandler.ButtonText = "changes have been saved";
                    }
                }

                else
                {
                    fileHandler.ButtonText = "one or both given paths do not exist";
                }
            }
        }

        public void CreateNewProfile()
        {
            //loading document
            XDocument xdoc = document;

            //creating new elements
            var projects = new XElement("project");
            var projectName = new XElement("projectName");
            var projectSourcePath = new XElement("projectSourcePath");
            var projectTargetPath = new XElement("projectTargetPath");
            var projectFiles = new XElement("projectFiles");

            //giving values to elements
            projectName.Value = project.ProjectName;

            //adding elements to file
            xdoc.Element("projects").Add(projects);
            projects.Add(projectName, projectSourcePath, projectTargetPath, projectFiles);

            xdoc.Save(xmlPath);
        }
    }
} 


