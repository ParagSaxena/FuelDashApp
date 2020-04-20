using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class PrioritiesProvider
    {
        public static async Task<List<Priority>> GetPrioritiesAsync()
        {
           
            var response = await new APIData().GetData<Priorities>(APIUrlConstant.GetPrioritiesApi);
            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
