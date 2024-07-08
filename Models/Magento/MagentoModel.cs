using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdobeAPI.Models.Magento
{
    public class MagentoModel
    {
        private readonly LoginModel _login;
        private readonly IConfiguration _config;
        public MagentoModel(LoginModel login, IConfiguration config)
        {
            _login = login;
            _config = config;
        }

        public async Task<string> GetOrders(string directoryLink){
                        string name = "warehouse";
            string password = "s0kSjrJ8s1nd112";
            string token = _login.Login(name,password,_config["LoginAPI"]).Result;
            using (HttpClient httpClient = new HttpClient())
            {
              var loginModel = new
              {
                Authorization = "Bearer" +token
              
            };
               
              var json = JsonConvert.SerializeObject(loginModel);
              var content = new StringContent(json, Encoding.UTF8, "application/json");               
              HttpResponseMessage response = await httpClient.PostAsync(directoryLink,content);
              
              HttpContent responseContent = response.Content;
              
              using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
              {
               return await reader.ReadToEndAsync();
              }
            }          
        }
    }
}