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
        private RegistrationDbContext _context;
        public StudentController(RegistrationDbContext dbContext)
        {
            this._context = dbContext;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudentInfo()
        {
            return View(_context.Students.ToList());
        }

        [HttpPost]
        public IActionResult Results(string searchTerm)
        {
            ViewBag.searchTerm = searchTerm;
            List<Student> resultsList = new List<Student>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                //resultsList = StudentData.Students;
                return Redirect("StudentInfo");
            }
            

            foreach (var i in _context.Students)
            {
                if (i.FName.ToLower() == searchTerm.ToLower().Trim() || i.LName.ToLower() == searchTerm.ToLower().Trim())
                {
                    resultsList.Add(i);
                }
            }
            return View(resultsList);
        }


        public IActionResult HyperLink(CareerPathType searchTerm)
        {
            ViewBag.searchTerm = searchTerm;
            List<Student> cpMatch = new List<Student>();

            foreach (var i in _context.Students)
            {
                if (i.CareerPath == searchTerm)
                {
                    cpMatch.Add(i);

                }
            }
            return View(cpMatch);
        }





    }
}
