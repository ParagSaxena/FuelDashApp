using FuelDashApp.Business.BusinessServices;
using FuelDashApp.Business.BusinessServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FuelDashApp.API.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController: ApiController
    {
        private IUserService _user;
        [HttpGet]
        [Route("GetData")]
        public string GetApi()
        {

            if (_user == null) _user = new UserService();
            return _user.GetApi();
        }

    }
}