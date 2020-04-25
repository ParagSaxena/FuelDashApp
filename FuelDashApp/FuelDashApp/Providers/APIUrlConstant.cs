using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Providers
{
    public class APIUrlConstant
    {
        public const string BASE_URL = HostURL + "api/";
        public const string HostURL = "http://184.164.128.36/";
        public const string GetDepartmentsApi = "User/GetDepartments";
        public const string GetPrioritiesApi = "User/GetPriority";
        public const string GetSitesApi = "User/GetSites";
        public const string CreateWorkOrderApi = "User/InsertWorkOrder";

    }
}
