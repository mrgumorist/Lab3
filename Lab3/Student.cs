using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [Serializable]
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public int GroupNumber { get; set; }
        public int CourseNumber { get; set; }
        public bool IsOnFreeStudy { get; set; }
        public double AvarageMark { get; set; }
        public uint CountOfMissedLections { get; set; }
        public Student()
        {
            this.ID = -1;
            this.Name = "Andrew";
            this.Surname = "Kek";
            this.BirthDay = new DateTime(2000, 10, 20);
            this.GroupNumber = 25;
            this.CourseNumber = 1;
            this.IsOnFreeStudy = true;
            this.AvarageMark = 4.5;
            this.CountOfMissedLections = 31;
        }
        public Student(int ID,string Name, string Surname, DateTime BirthDay, int GroupNumber, int CourseNumber, bool IsOnFreeStudy, double AvarageMark, uint CountOfMissedLections)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDay = BirthDay;  
            this.GroupNumber = GroupNumber;
            this.CourseNumber = CourseNumber;
            this.IsOnFreeStudy = IsOnFreeStudy;
            this.AvarageMark = AvarageMark;
            this.CountOfMissedLections = CountOfMissedLections;
        }
       
    }
}
