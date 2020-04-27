using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class SitesProvider
    {
        public static async Task<List<Site>> GetSitesAsync()
        {
           
            var response = await new APIData().GetData<SiteResponse>(APIUrlConstant.GetSitesApi);
            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
