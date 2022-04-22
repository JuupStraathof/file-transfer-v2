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
                    xmlHandler.fileProperties.FolderDate = DateTime.Today.ToString(xmlHandler.project.ProjectDateFormat);
                    Directory.CreateDirectory(xmlHandler.project.ProjectTargetPath + "/" + xmlHandler.fileProperties.FolderDate.ToString());
                    foreach (string s in xmlHandler.project.ProjectFiles)
                    {
                        File.Copy(xmlHandler.project.ProjectSourcePath + "/" + s, xmlHandler.project.ProjectTargetPath + "/" +xmlHandler.fileProperties.FolderDate + "/" + s, true);
                    }
                    xmlHandler.fileProperties.ButtonText = "Copying completed";
                }

                if (fileFlag == false)
                {
                    xmlHandler.fileProperties.ErrorMessage = "Some files could not be found";
                }
            }
        }
    }
}
