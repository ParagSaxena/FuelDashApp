using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuelDashApp.Services
{
    public interface IHttpService
    {
        Task<int> RegiserUser(string url, string data = "", Action<int> callback = null);
        Task<List<Role>> GetRoles(string url, Action<List<Role>> callback = null);
    }
}
