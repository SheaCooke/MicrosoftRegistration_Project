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
        public IActionResult Index()
        {
            return View();
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

                StudentData.Add(newStudent);
                return Redirect("/Student/StudentInfo");
            }

            return View(registerUserViewModel);
        }



        
        public IActionResult Edit(int id)
        {
            ViewBag.Student = StudentData.GetById(id);
            RegisterUserViewModel registerUserViewModel = new RegisterUserViewModel();

            return View(registerUserViewModel);
        }



        [HttpPost]
        
        public IActionResult Edit(RegisterUserViewModel registerUserViewModel, int id)
        {
            

            if (ModelState.IsValid)
            {
                StudentData.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.FName = registerUserViewModel.FName);
                StudentData.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.LName = registerUserViewModel.LName);
                StudentData.Students.Where(x => x.StudentID == id).ToList().ForEach(x => x.CareerPath = registerUserViewModel.CareerPath);



                return Redirect("/Student/StudentInfo");
            }

            ViewBag.Student = StudentData.GetById(id);

            return View(registerUserViewModel);


        }




        [Route("/User/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View("Delete", StudentData.GetById(id));
        }


        [HttpPost]
        [Route("/User/Delete/{id}")]
        public IActionResult DeletePost(int id)
        {
            StudentData.RemoveById(id);
            return Redirect("/Student/StudentInfo");
        }



    }
}
