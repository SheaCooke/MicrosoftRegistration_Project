using Microsoft.AspNetCore.Mvc;
using MicroSoftRegistration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroSoftRegistration.Models;

namespace MicroSoftRegistration.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudentInfo()
        {
            return View(StudentData.Students);
        }

        [HttpPost]
        public IActionResult Results(string searchTerm)
        {
            List<Student> resultsList = new List<Student>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                resultsList = StudentData.Students;
                return View(resultsList);
            }
            

            foreach (var i in StudentData.Students)
            {
                if (i.FName.ToLower() == searchTerm.ToLower().Trim() || i.LName.ToLower() == searchTerm.ToLower().Trim())
                {
                    resultsList.Add(i);
                }
            }
            return View(resultsList);
        }





    }
}
