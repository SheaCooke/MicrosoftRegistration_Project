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
                    //StudentID = registerUserViewModel.StudentID
                };

                StudentData.Add(newStudent);
                return Redirect("/Student/StudentInfo");
            }

            return View(registerUserViewModel);
        }
    }
}
