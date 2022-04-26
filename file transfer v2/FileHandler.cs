using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace file_transfer_v2
{
    public class FileHandler
    {
        public void CopyFiles(int ProjectId, XmlHandler xmlHandler)
        {
            bool fileFlag = true;
            bool invalidPath = true;
            xmlHandler.fileProperties.FolderDate = DateTime.Today.ToString(xmlHandler.project.ProjectDateFormat);
            try
            {
                Directory.CreateDirectory(xmlHandler.project.ProjectTargetPath + "/" + xmlHandler.fileProperties.FolderDate.ToString());
                invalidPath = false;
            }
            catch
            {
                xmlHandler.fileProperties.ErrorMessage = "invalid path";
                invalidPath = true;
            }

            if (invalidPath == false)
            {
                if (ProjectId == 0)
                {
                    xmlHandler.fileProperties.ErrorMessage = "You can't copy this preset";
                }
                else
                {
                    foreach (string s in xmlHandler.project.ProjectFiles)
                    {
                        //checks if files exists
                        if (!File.Exists(xmlHandler.project.ProjectSourcePath + "/" + s))
                        {
                            fileFlag = false;
                        }
                    }

                    if (fileFlag == true)
                    {
                        //if all files exist then the copying process is started
                        Directory.CreateDirectory(xmlHandler.project.ProjectTargetPath + "/" + xmlHandler.fileProperties.FolderDate.ToString());
                        foreach (string s in xmlHandler.project.ProjectFiles)
                        {
                            File.Copy(xmlHandler.project.ProjectSourcePath + "/" + s, xmlHandler.project.ProjectTargetPath + "/" + xmlHandler.fileProperties.FolderDate + "/" + s, true);
                        }
                        xmlHandler.fileProperties.ButtonText = "Copying completed";
                    }

                    if (fileFlag == false)
                    {
                        xmlHandler.fileProperties.ErrorMessage = "Some files could not be found";
                    }
                }
            }
            else
            {
                xmlHandler.fileProperties.ErrorMessage = "invalid path";
            }
        }
    }
}
