using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class DepartmentsProvider
    {
        public static async Task<List<Department>> GetDepartmentsAsync()
        {
           
            var response = await new APIData().GetData<Departments>(APIUrlConstant.GetDepartmentsApi);
            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
