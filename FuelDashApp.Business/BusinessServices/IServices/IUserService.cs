using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelDashApp.Business.BusinessDTO;

namespace FuelDashApp.Business.BusinessServices
{
    public interface IUserService
    {
        string GetApi();
        ResponseDTO UserLogin(string email, string password);
        int UserRegistration(User userData);
        ResponseDTO ForgotPassword(string email);
        List<RoleDTO> GetRole();
        bool GetUserByEmail(string email);
        List<DepartmentDTO> GetDepartments();
        List<JobSiteDTO> GetSites();
        int InsertPasscode(PasscodeDTO data);
        void UpdatePasscode(PasscodeDTO data);
        PasscodeDTO GetPasscode();
        JobSiteDTO GetSitesBySiteID(int siteID);
        List<PriorityDTO> GetPriority();
        int InsertWorkOrder(WorkOrderDTO data);

        //ResponseDTO Login(string emailAddress, string password);
        //ResponseDTO ForgotPassword(string emailAddress);
        //ResponseDTO Registration(Candidate candidate);
    }

}
