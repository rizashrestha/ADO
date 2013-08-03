using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentEntities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string TeacherID { get; set; }
        public string Grade { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public int TotalMarks { get; set; }

    }
}
