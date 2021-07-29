﻿using Microsoft.AspNetCore.Mvc;
using MicroSoftRegistration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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






    }
}
