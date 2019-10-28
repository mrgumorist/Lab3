using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3
{
    public class Helper
    {
        public List<Student> students= new List<Student>() { new Student(), new Student()  , new Student() };
        XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
        public Helper()
        {
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                List<Student> newpeople = (List<Student>)formatter.Deserialize(fs);
                students.Clear();
                students.AddRange(newpeople);
            }
        }
        public void Serialize()
        {
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, students); 
            }
        }
    }
}
