using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class RolesProvider
    {
        public  static async Task<List<Role>> GetRolesAsync()
        {
            var roles = await Constants.HttpSerivceInstance.GetRoles(Constants.GetRolesApi);
            return roles;
        }
    }
}
