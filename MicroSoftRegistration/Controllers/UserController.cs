using Microsoft.AspNetCore.Mvc;
using MicroSoftRegistration.Models;
using MicroSoftRegistration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroSoftRegistration.Data;

namespace MicroSoftRegistration.Controllers
{
    public class UserController : Controller
    {
        private RegistrationDbContext _context;
        public UserController(RegistrationDbContext dbContext)
        {
            this._context = dbContext;
        }

        public IActionResult Index()
        {
            List<Student> Students = _context.Students.ToList();
            return View(Students);
        }

        public IActionResult Register()
        {
            RegisterUserViewModel registerUserViewModel = new RegisterUserViewModel();
            

            return View(registerUserViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = new Student
                {
                    FName = registerUserViewModel.FName,
                    LName = registerUserViewModel.LName,
                    CareerPath = registerUserViewModel.CareerPath,
                    
                };

                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return Redirect("/Student/StudentInfo");
            }

            return View(registerUserViewModel);
        }



        
        public IActionResult Edit(int id)
        {
            ViewBag.Student = _context.Students.Find(id);
            RegisterUserViewModel registerUserViewModel = new RegisterUserViewModel();

            return View(registerUserViewModel);
        }



        [HttpPost]
        
        public IActionResult Edit(RegisterUserViewModel registerUserViewModel, int id)
        {
            

            if (ModelState.IsValid)
            {
                _context.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.FName = registerUserViewModel.FName);
                _context.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.LName = registerUserViewModel.LName);
                _context.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.CareerPath = registerUserViewModel.CareerPath);


                _context.SaveChanges();
                return Redirect("/Student/StudentInfo");
            }

            ViewBag.Student = _context.Students.Find(id);

            return View(registerUserViewModel);


        }




        [Route("/User/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View("Delete", _context.Students.Find(id));
        }


        [HttpPost]
        [Route("/User/Delete/{id}")]
        public IActionResult DeletePost(int id)
        {
            Student removeStudent = _context.Students.Find(id);
            _context.Students.Remove(removeStudent);
            _context.SaveChanges();
            return Redirect("/Student/StudentInfo");
        }



    }
}
