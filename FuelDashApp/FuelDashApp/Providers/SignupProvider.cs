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
        public static async Task<bool> SignupAsync(string firstName, string lastName, int roleId, string email, string password, string phoneNumber, string address, string city, string state, string zip, string profileImage)
        {
            var signupRequest = new SignupRequest()
            {
                FirstName = firstName,
                LastName = lastName,
                RoleId = roleId,
                Email = email,
                Password = password,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                ProfileImage = profileImage
            };

            var json = JsonConvert.SerializeObject(signupRequest);
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
