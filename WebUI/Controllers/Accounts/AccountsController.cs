﻿using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Users.Commands.Create;
using Application.Users.Queries.GetByNameAndPassword;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AccountsController : BaseController<AccountsController>
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn([FromForm] GetUserByNameAndPasswordQuery command) 
        {
            var user = await Mediator.Send(command);
            Result result;

            if (user != null)
            {
                await Authenticate(command.UserName);
                result = Result.Success();
                result.IsRedirect = true;
                result.RedirectAddress = this.Url.Action("List", "Projects");
                return Json(result);
            } else 
            {
                result = Result.Error(new List<string> { "Invalid user name or password." });
            }    
            
           return Json(result);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] CreateUserCommand command)
        { 
            var result = await Mediator.Send(command);

            if (result.Succeded)
            {
                await Authenticate(command.UserName);
                result.IsRedirect = true;
                result.RedirectAddress = this.Url.Action("List", "Projects");
                return Json(result);
            }

            result.Errors.Append("Test error 1");
            return Json(result);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
        
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
      
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SingIn", "Accounts");
        }
    }
}
