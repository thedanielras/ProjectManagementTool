using Application.Common.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult SingIn() 
        {


            return View();
        }

        [HttpPost]
        public IActionResult SingIn(string userName, string password) 
        {
            var loginSuccessful = true;
            var errorMessage = "User not found!";

            var user = _userRepository.AllUsers.Where(u => u.Name == userName && u.Password == password).FirstOrDefault();
            if (user == null) 
            {
                loginSuccessful = false;
            }

            if (loginSuccessful)
            {
                Response.Cookies.Append("username", user.Name);
                Response.Cookies.Append("password", user.Password);
                return new RedirectToActionResult("List", "Projects", new { });
            } else 
            {
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }           
        }
    }
}
