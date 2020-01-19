using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlAssign
{
    public class information
    {
        private string txtdata1;
        private string txtdata2;

        public string ID {
            get{return txtdata1;}
            set { txtdata1 = value; }
        }
        public string Name {
            get { return txtdata2; }
            set { txtdata2 = value; }
        }
       }
 }

