using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroSoftRegistration.ViewModels;

namespace MicroSoftRegistration.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public CareerPathType CareerPath { get; set; }

        //private static int NextID = 1;


        public Student()
        {
            /*this.StudentID = NextID;
            NextID++;*/
        }

        public Student(int studentID, string fName, string lName, CareerPathType careerPath) :this()
        {
            
            this.FName = fName;
            this.LName = lName;
            this.CareerPath = careerPath;
        }
    }


   
}
