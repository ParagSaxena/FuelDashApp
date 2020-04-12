using FuelDashApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class ForgotPasswordProvider
    {
        public static async Task<bool> ChangePasswordAsync(string email)
        {
            var request = new ForgotPasswordRequest()
            {
                Email = email
            };
            var json = JsonConvert.SerializeObject(request);
            var result = await Constants.HttpSerivceInstance.PostData(Constants.ForgotPasswordApi, json);
            if (result != null && result.IsSuccess)
            {
                return true;
            }
            return false;
        }
    }
}
