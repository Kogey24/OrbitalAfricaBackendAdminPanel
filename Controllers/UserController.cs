﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orbital_Africa_Backend_Recon.Modal;
using Orbital_Africa_Backend_Recon.Service;

namespace Orbital_Africa_Backend_Recon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class UserController : ControllerBase
    {
        private readonly IuserService service;
        public UserController(IuserService service)
        {
            this.service = service;
        }

        [HttpPost("UserRegistration")]
        public async Task<IActionResult> UserRegistration(UserRegister userRegister)
        {
            var data = await this.service.UserRegistration(userRegister);
            return Ok(data);
        }

        [HttpPost("CustomerRegistration")]
        public async Task<IActionResult> CustomerRegistration(CustomerRegister customer)
        {
            var data = await this.service.CustomerRegistration(customer);
            return Ok(data);
        }

        [HttpPost("ConfirmRegistration")]
        public async Task<IActionResult> Confirmregistration(int userid, string username, string otptext)
        {
            var data = await this.service.ConfirmRegistration(userid, username, otptext);
            return Ok(data);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string username, string oldpassword, string newpassword)
        {
            var data = await this.service.ResetPassword(username, oldpassword, newpassword);
            return Ok(data);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            var data = await this.service.ForgotPassword(username);
            return Ok(data);
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string username, string password, string otptext)
        {
            var data = await this.service.UpdatePassword(username, password, otptext);
            return Ok(data);
        }


        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(string username, bool userstatus)
        {
            var data = await this.service.UpdateStatus(username, userstatus);
            return Ok(data);
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(string username, string userrole)
        {
            var data = await this.service.UpdateRole(username, userrole);
            return Ok(data);
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var data = await this.service.GetUsers();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
