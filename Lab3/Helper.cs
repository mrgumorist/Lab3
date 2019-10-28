using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3
{
    public static class Helper
    {
        public static List<Student> students = new List<Student>();
        static XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));

        public static void Deserialize()
        {
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                students = (List<Student>)formatter.Deserialize(fs);
            }
        }
        public static void Serialize()
        {
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, students); 
            }
        }
        public static void DeleteByNum(int num)
        {
            students.RemoveAt(num);
        }
        public static int GetID()
        {
            int ID = students.Count + 1;
            return ID;
        }
    }
}
