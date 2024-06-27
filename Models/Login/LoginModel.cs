using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdobeAPI.Models.Login
{
    public class LoginModel
    {
        private readonly IConfiguration _config;

        public LoginModel(IConfiguration configuration){
            _config = configuration;
        }

        public async Task<string> Login(string name, string password){
            using (HttpClient httpClient = new HttpClient())
            {
              var loginModel = new
              {
              Username = name,
              Password = password
            };

              var json = JsonConvert.SerializeObject(loginModel);
              var content = new StringContent(json, Encoding.UTF8, "application/json");               
              HttpResponseMessage response = await httpClient.PostAsync(_config["LoginAPI"],content);
              HttpContent responseContent = response.Content;

              using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
              {
               return await reader.ReadToEndAsync();
              }
            }          
        }
    }
}