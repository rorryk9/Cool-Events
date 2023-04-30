using CoolEvents.Models.DTOs;
using CoolEvents.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolEvents.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);

            UserDTO userDTO = new UserDTO();
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;

            return View(userDTO);
        }
    }
}
