using FuelDashApp.Models;
using FuelDashApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class SignupProvider
    {
        public static async Task<bool> SignupAsync(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var httpSerivce = new HttpService();
            var response = await httpSerivce.RegiserUser(Constants.UserRegistrationApi, json);
            if (response > 0)
            {
                return true;
            }
            return false;
        }
    }
}
