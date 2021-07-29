using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MicroSoftRegistration.Models;

namespace MicroSoftRegistration.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "This field cannot be blank")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "This field cannot be blank")]
        public string FName { get; set; }

        [Required(ErrorMessage = "This field cannot be blank")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Select an option")]
        public CareerPathType CareerPath { get; set; }

        public List<SelectListItem> CareerPathList = new List<SelectListItem>
        {
            new SelectListItem(CareerPathType.Artificial_Intelligence.ToString(), ((int)CareerPathType.Artificial_Intelligence).ToString()),
            new SelectListItem(CareerPathType.Machine_Learning.ToString(), ((int)CareerPathType.Machine_Learning).ToString()),
            new SelectListItem(CareerPathType.Security.ToString(), ((int)CareerPathType.Security).ToString()),
            new SelectListItem(CareerPathType.Web_Development.ToString(), ((int)CareerPathType.Web_Development).ToString()),
            new SelectListItem(CareerPathType.Devops.ToString(), ((int)CareerPathType.Devops).ToString())

        };

        

















    }
}
