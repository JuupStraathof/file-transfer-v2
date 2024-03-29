﻿using System;
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
        private FileInfo _fileInfo;
        public FrmSelectProfile()
        {
            InitializeComponent();
            _fileInfo = new FileInfo();
             
        }
        List<FileInfo> lstFileInfo = new List<FileInfo>();
        public string xmlPath = "..\\..\\..\\Database.xml";
        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            bool fileFlag = true;
            if (CmbSelectProfile.SelectedIndex == 0)
            {
                MessageBox.Show("you can't copy this preset");
            }
            else
            {
                foreach (string s in _fileInfo.ProjectFiles)
                {
                    if (!File.Exists(_fileInfo.ProjectSourcePath + "/" + s))
                    {
                        fileFlag = false;
                    }
                }
                if (Directory.Exists(_fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString()))
                {
                    if (fileFlag == true)
                    {
                        var MessageCaption = "warning";
                        var messageString = "the following directory already exists: " + _fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString() + "\n do you want to overwrite it?";
                        var result = MessageBox.Show(messageString, MessageCaption, MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            MessageBox.Show("the copying of files has been aborted");
                        }

                        if (result == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(_fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString());
                            foreach (string s in _fileInfo.ProjectFiles)
                            {
                                //bug can't find path
                                File.Copy(_fileInfo.ProjectSourcePath + "/" + s, _fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd") + "/" + s, true);
                            }
                            MessageBox.Show("copying of files has been completed");
                        }
                    }
                }
                else
                { 
                    if (fileFlag == true)
                    {
                        Directory.CreateDirectory(_fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd").ToString());
                        foreach (string s in _fileInfo.ProjectFiles)
                        { //can't find file path 
                            File.Copy(_fileInfo.ProjectSourcePath + "/" + s, _fileInfo.ProjectTargetPath + "/" + DateTime.Now.ToString("yyMMdd") + "/" + s, true);
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
            Form ProfileManagerForm = new ProfileManager();

            ProfileManagerForm.ShowDialog();
        }
        

        private void CmbSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = CmbSelectProfile.SelectedIndex;
            int idirator = 0;
            _fileInfo.ProjectFiles.Clear();
            //reading data from xml
            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
            {
                if (idirator == projectId)
                {
                    //execute stuff
                    foreach (var child in projectElement.Elements())
                    {
                        if (child.Name == "projectName")
                        {
                            _fileInfo.ProjectName = child.Value;
                        }

                        if (child.Name == "projectSourcePath")
                        {
                            _fileInfo.ProjectSourcePath = child.Value;
                        }

                        if (child.Name == "projectTargetPath")
                        {
                            _fileInfo.ProjectTargetPath = child.Value;
                        }

                        if (child.Name == "projectFiles")
                        {
                            foreach (var decentand in child.Descendants())
                            {
                                if (decentand.Name == "File")
                                {
                                    _fileInfo.ProjectFiles.Add(decentand.Value);
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
            foreach (XElement projectElement in XElement.Load(xmlPath).Elements("project"))
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
        
        public class FileInfo
        {
            // class for making objects to read and write to xml file
            public string ProjectName { get; set; }
            public List<string> ProjectFiles = new List<string>();
            public string ProjectSourcePath { get; set; }
            public string ProjectTargetPath { get; set; }
        }
    }
}
