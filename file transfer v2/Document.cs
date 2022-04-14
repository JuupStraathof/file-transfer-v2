using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace file_transfer_v2
{
    class Document
    {
        public XDocument document = XDocument.Load("Database.xml");
    }
}
