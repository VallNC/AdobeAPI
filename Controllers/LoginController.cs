global using AdobeAPI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdobeAPI.Models.Magento;
using Microsoft.AspNetCore.Mvc;

namespace AdobeAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel _loginModel;
        private readonly IConfiguration _config;
        private readonly MagentoModel _magento;
        public LoginController(LoginModel loginModel, IConfiguration config, MagentoModel magentoModel)
        {
            _loginModel = loginModel;
            _config = config;
            _magento = magentoModel;
        }

        [HttpGet("Ping")]
        public IActionResult Ping(){
            return Ok("Pinged");
        }

        [HttpGet("GetLogin")]
        
        public IActionResult Login(string name, string password){
            if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(password))
            return BadRequest("Bad input for name or password");
            if(!String.IsNullOrEmpty(_config["LoginAPI"]) )
            return Ok(_loginModel.Login(name,password,_config["LoginAPI"]).Result);
            else return StatusCode(500, "An error has occured with the login.");
        }

          [HttpGet("GetMagentoOrders")]
        public IActionResult GetMagentoOrders(){

            return Ok(_magento.GetOrders(_config["MagentoAPI"]).Result);
        }
    }
}