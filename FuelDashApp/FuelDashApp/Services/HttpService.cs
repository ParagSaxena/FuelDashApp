using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FuelDashApp.Models;
using Newtonsoft.Json;

namespace FuelDashApp.Services
{
    public class HttpService : IHttpService
    {
        public async Task<List<Role>> GetRoles(string url, Action<List<Role>> callback = null)
        {
            List<Role> roleRepsonse = new List<Role>();
            roleRepsonse.Add(new Role { RoleName = "Admin", RoleId = 1, IsActive = true });
            roleRepsonse.Add(new Role { RoleName = "Manager", RoleId = 2, IsActive = true });
            roleRepsonse.Add(new Role { RoleName = "Technician", RoleId = 3, IsActive = true });
            roleRepsonse.Add(new Role { RoleName = "Office", RoleId = 4, IsActive = true });
            roleRepsonse.Add(new Role { RoleName = "Customer", RoleId = 5, IsActive = true });
            //var uri = new Uri(url);
            //try
            //{
            //    HttpResponseMessage response = null;
            //    HttpClient client = new HttpClient();
            //    response = await client.GetAsync(uri);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseContent = await response.Content.ReadAsStringAsync();
            //        roleRepsonse = JsonConvert.DeserializeObject<List<Role>>(responseContent);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"ERROR {0} URL:{1}", ex.Message, url);
            //}
            //callback?.Invoke(roleRepsonse);

            return roleRepsonse;
        }

        public async Task<int> RegiserUser(string url, string data = "", Action<int> callback = null)
        {
            int baseResponse = -1;
            var uri = new Uri(url);
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                HttpClient client = new HttpClient();
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    baseResponse = JsonConvert.DeserializeObject<int>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0} URL:{1}", ex.Message,url);
            }
            callback?.Invoke(baseResponse);

            return baseResponse;

        }

        public async Task<BaseResponse> PostData(string url, string data = "", Action<BaseResponse> callback = null)
        {
            BaseResponse roleRepsonse = new BaseResponse();
            var uri = new Uri(url);
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                HttpClient client = new HttpClient();
                response = await client.PostAsync(uri,content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    roleRepsonse = JsonConvert.DeserializeObject<BaseResponse>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0} URL:{1}", ex.Message, url);
            }
            callback?.Invoke(roleRepsonse);

            return roleRepsonse;
        }
    }
}
