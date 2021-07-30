using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroSoftRegistration.Models;

namespace MicroSoftRegistration.Data
{
    public class StudentData
    {
        public static List<Student> Students= new List<Student>();

        public static void Add(Student newStudent)
        {
            Students.Add(newStudent);
        }

        public static Student GetById(int id)
        {
            return Students.First(x => x.StudentID == id);
        }

        



        public static void RemoveById(int id)
        {
            Students.Remove(GetById(id));
        }




    }
}
