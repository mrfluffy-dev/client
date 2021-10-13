using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalPojectPRG282
{
    class Student
    {
        string StudentNumber, StudentName, StudentSurname ;
        Image StudentImage;
        DateTime DOB;
        string StudentGender, StudentPhone, StudentAddres, StudentModule;

        public Student(string studentNumber, string studentName, string studentSurname, Image studentImage, DateTime dOB, string studentGender, string studentPhone, string studentAddres, string studentModule)
        {
            StudentNumber1 = studentNumber;
            StudentName1 = studentName;
            StudentSurname1 = studentSurname;
            StudentImage1 = studentImage;
            DOB1 = dOB;
            StudentGender1 = studentGender;
            StudentPhone1 = studentPhone;
            StudentAddres1 = studentAddres;
            StudentModule1 = studentModule;
        }

        public string StudentNumber1 { get => StudentNumber; set => StudentNumber = value; }
        public string StudentName1 { get => StudentName; set => StudentName = value; }
        public string StudentSurname1 { get => StudentSurname; set => StudentSurname = value; }
        public Image StudentImage1 { get => StudentImage; set => StudentImage = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string StudentGender1 { get => StudentGender; set => StudentGender = value; }
        public string StudentPhone1 { get => StudentPhone; set => StudentPhone = value; }
        public string StudentAddres1 { get => StudentAddres; set => StudentAddres = value; }
        public string StudentModule1 { get => StudentModule; set => StudentModule = value; }
    }
}
