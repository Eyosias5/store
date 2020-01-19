using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlAssign
{
    class SaveXml
    {
        public static void savedata(object obj, string name) {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(name);
            sr.Serialize(writer, obj);
            writer.Close();
        }
    }
}
