using FuelDashApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class LoginProvider
    {
        public static async Task<bool> LoginAsync(string email, string password)
        {
            var loginRequest = new LoginRequest()
            {
                Email = email,
                Password = password
            };
            var json = JsonConvert.SerializeObject(loginRequest);
            var response = await Constants.HttpSerivceInstance.PostData(Constants.UserLoginApi, json);
            if (response != null && response.IsSuccess)
            {
                return true;
            }
            return false;
        }
    }
}
