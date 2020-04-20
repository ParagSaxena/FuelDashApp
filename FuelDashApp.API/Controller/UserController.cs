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
    public class UserController : ApiController
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
        [HttpGet]
        [Route("GetUserByEmail")]
        public bool GetUserByEmail(string email)
        {
            if (_user == null) _user = new UserService();
            return _user.GetUserByEmail(email);
        }

        [HttpGet]
        [Route("GetDepartments")]
        public List<DepartmentDTO> GetDepartments()
        {
            List<DepartmentDTO> departmentList = new List<DepartmentDTO>();
            User user = new User();
            if (_user == null) _user = new UserService();
            departmentList = _user.GetDepartments();
            return departmentList;
        }

        [HttpGet]
        [Route("GetSites")]
        public List<JobSiteDTO> GetSites()
        {
            List<JobSiteDTO> siteList = new List<JobSiteDTO>();
            User user = new User();
            if (_user == null) _user = new UserService();
            siteList = _user.GetSites();
            return siteList;
        }
        [HttpPost]
        [Route("InsertPasscode")]
        public int InsertPasscode(PasscodeDTO data)
        {
            int passcodeId = 0;
            PasscodeDTO user = new PasscodeDTO();
            if (_user == null) _user = new UserService();
            passcodeId = _user.InsertPasscode(data);
            return passcodeId;

        }

        [HttpPost]
        [Route("UpdatePasscode")]
        public void UpdatePasscode(PasscodeDTO data)
        {

            PasscodeDTO user = new PasscodeDTO();
            if (_user == null) _user = new UserService();
            _user.UpdatePasscode(data);

        }
        [HttpGet]
        [Route("GetPassCode")]
        public PasscodeDTO GetPasscode()
        {
            if (_user == null) _user = new UserService();
            PasscodeDTO passcode = _user.GetPasscode();
            return passcode;
        }

        [HttpGet]
        [Route("GetSitesBySiteID")]
        public JobSiteDTO GetSitesBySiteID(int siteID)
        {
           
            if (_user == null) _user = new UserService();
            JobSiteDTO site = _user.GetSitesBySiteID(siteID);
            return site;

        }
        [HttpGet]
        [Route("GetPriority")]
        public List<PriorityDTO> GetPriority()
        {
            if (_user == null) _user = new UserService();
            return _user.GetPriority();
        }
        [HttpPost]
        [Route("InsertWorkOrder")]
        public int InsertWorkOrder(WorkOrderDTO data)
        {
            int workorderId = 0;
            WorkOrderDTO user = new WorkOrderDTO();
            if (_user == null) _user = new UserService();
            workorderId = _user.InsertWorkOrder(data);
            return workorderId;

        }
    }
}