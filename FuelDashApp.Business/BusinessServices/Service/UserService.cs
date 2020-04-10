using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDashApp.Business.BusinessServices.Service
{
    public class UserService:IUserService
    {
        public string GetApi()
        {
            return "Welcome in the portal of FUELDASH.";
        }
    }
}