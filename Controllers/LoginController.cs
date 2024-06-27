global using AdobeAPI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdobeAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel _loginModel;

        public LoginController(LoginModel loginModel)
        {
            _loginModel = loginModel;
        }

        [HttpGet("Ping")]
        public IActionResult Ping(){
            return Ok("Pinged");
        }

        [HttpGet("Get Login")]
        public IActionResult Login(string name, string password){
            return Ok(_loginModel.Login(name,password).Result);
        }
    }
}