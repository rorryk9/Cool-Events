﻿using CoolEvents.Models.DTOs;
using CoolEvents.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolEvents.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                return View();
            }

            User user = new User();
            user.UserName = userDTO.UserName;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;

            IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            List<IdentityError> errors = new List<IdentityError>(result.Errors);
            ViewData["errors"] = errors;

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["errorMessage"] = "Username or password is incorrect!";

            return View();
        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
