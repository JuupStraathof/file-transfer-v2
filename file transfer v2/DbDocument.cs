using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace file_transfer_v2
{
    public class DbDocument
    {
        public XDocument document = XDocument.Load("Database.xml");
    }
}
