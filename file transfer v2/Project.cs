using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_transfer_v2
{
    public class Project
    {
        // class for making objects to read and write to xml file
        public string ProjectName { get; set; }

        public List<string> ProjectFiles = new List<string>();

        public string ProjectSourcePath { get; set; }

        public string ProjectTargetPath { get; set; }

        public string ProjectDateFormat { get; set; }

        public string LastUsedProject { get; set; }
    }
}

