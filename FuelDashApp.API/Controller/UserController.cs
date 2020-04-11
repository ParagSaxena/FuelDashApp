using FuelDashApp.Business.BusinessDTO;
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

        [HttpPost]
        [Route("UserLogin")]
        public ResponseDTO UserLogin(LoginDTO loginDetail)
        {
            if (_user == null) _user = new UserService();
            ResponseDTO loginResponce = _user.UserLogin(loginDetail.Email, loginDetail.Password);
            return loginResponce;
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ResponseDTO ForgotPassword(LoginDTO loginDetail)
        {
            if (_user == null) _user = new UserService();
            ResponseDTO loginResponce = _user.ForgotPassword(loginDetail.Email);
            return loginResponce;
        }

        [HttpPost]
        [Route("Registration")]
        public int Registration(User userData)
        {
            int userId = 0;
            User user = new User();
            if (_user == null) _user = new UserService();
            userId = _user.UserRegistration(userData);
            return userId;
          
        }
        [HttpGet]
        [Route("GetRole")]
        public List<RoleDTO> GetRole()
        {
            List<RoleDTO> roleList = new List<RoleDTO>();
            User user = new User();
            if (_user == null) _user = new UserService();
            roleList = _user.GetRole();
            return roleList;
        }
    }
}