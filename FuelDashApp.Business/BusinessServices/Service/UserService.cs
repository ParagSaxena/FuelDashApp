using FuelDashApp.Business.BusinessDTO;
using Headway.Recruiting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using static FuelDashApp.Business.BusinessDTO.ActivityStatus;

namespace FuelDashApp.Business.BusinessServices.Service
{
    public class UserService : Base, IUserService
    {

        public string GetApi()
        {
            return "Welcome in the portal of FUELDASH.";
        }


        public ResponseDTO UserLogin(string email, string password)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                if ((!string.IsNullOrEmpty(email)) && (!string.IsNullOrEmpty(password)))
                {
                    SqlParameter paramEmail = new SqlParameter("email", email);
                    SqlParameter paramPassword = new SqlParameter("Password", password);
                    DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetUserByLogin", new SqlParameter[] { paramEmail, paramPassword });
                    BusinessDTO.User userData = new BusinessDTO.User();
                    if (dtUser != null && dtUser.Rows.Count > 0)
                    {
                        response.LoginResult = LoginResultType.Success;
                        response.IsSuccess = true;
                        response.Message = "login success";

                    }
                    else
                    {
                        response.LoginResult = LoginResultType.InvalidLogin;
                        response.Message = "fail";
                    }
                }
            }
            catch (Exception ex)
            {
                response.LoginResult = LoginResultType.InvalidLogin;
                response.ResponseData = null;
                response.Message = ex.Message;
            }
            return response;
        }
        public int UserRegistration(BusinessDTO.User userData)
        {
            int userId = 0;
            SqlParameter[] sqlParams = new SqlParameter[22];

            sqlParams[0] = new SqlParameter("UniqueID", userData.UniqueID);
            sqlParams[1] = new SqlParameter("RoleId", userData.RoleId);//
            sqlParams[2] = new SqlParameter("Password", userData.Password);//
            sqlParams[3] = new SqlParameter("IsActive", userData.IsActive);//
            sqlParams[4] = new SqlParameter("FirstName", userData.FirstName);//
            sqlParams[5] = new SqlParameter("HomeAddress", userData.HomeAddress);//
            sqlParams[6] = new SqlParameter("WMTechID", userData.WMTechID);//
            sqlParams[7] = new SqlParameter("ClockedIn", userData.ClockedIn);//
            sqlParams[8] = new SqlParameter("Company", userData.Company);//
            sqlParams[9] = new SqlParameter("Department", userData.Department);//
            sqlParams[10] = new SqlParameter("LaborRateCost", userData.LaborRateCost);//
            sqlParams[11] = new SqlParameter("LaborRateSell", userData.LaborRateSell);//
            sqlParams[12] = new SqlParameter("LastName", userData.LastName);//
            sqlParams[13] = new SqlParameter("CurrentLocation", userData.CurrentLocation);//
            sqlParams[14] = new SqlParameter("PayRate", userData.PayRate);//
            sqlParams[15] = new SqlParameter("PhoneNumber", userData.PhoneNumber);//
            sqlParams[16] = new SqlParameter("ProfilePicture", userData.ProfilePicture);//
            sqlParams[17] = new SqlParameter("TimeSheets", userData.TimeSheets);//
            sqlParams[18] = new SqlParameter("Title", userData.Title);//
            sqlParams[19] = new SqlParameter("Truck", userData.Truck);//
            sqlParams[20] = new SqlParameter("Type", userData.Type);//
                                                                    // sqlParams[21] = new SqlParameter("CreationDate", userData.CreationDate);
                                                                    //sqlParams[22] = new SqlParameter("UniqueID", userData.UniqueID);
            sqlParams[21] = new SqlParameter("Email", userData.Email);
            object objResult = SqlClientRMXProd.ExecuteScalar("udsp_User_Insert", sqlParams);
            if ((objResult != null) && (Int32.TryParse(objResult.ToString(), out userId)))
            {
                return userId;
            }
            return userId;
        }

        public ResponseDTO ForgotPassword(string email)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                if ((!string.IsNullOrEmpty(email)))
                {
                    SqlParameter paramEmail = new SqlParameter("email", email);
                    // SqlParameter paramPassword = new SqlParameter("Password", password);
                    DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetUserByEmail", new SqlParameter[] { paramEmail });
                    BusinessDTO.User userData = new BusinessDTO.User();
                    if (dtUser != null && dtUser.Rows.Count > 0)
                    {
                        MailMessage PwReminderEmail = new MailMessage
                        {
                            // email from address
                            From = new MailAddress(ConfigurationManager.AppSettings["SupportEmail"])
                        };
                        // email to address
                        PwReminderEmail.To.Add(email);
                        // email subject
                        PwReminderEmail.Subject = "FuelDashp password";
                        // email body
                        //PwReminderEmail.Body = emailSettings.Body;
                        string body = "<p>You were trying to retrive your password from FuelDash app. <br/><br/>Your password is " + dtUser.Rows[0]["Password"].ToString() + "  </p>";
                        PwReminderEmail.Body = body;
                        PwReminderEmail.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServer"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]));
                        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MailPassword"]))
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SupportEmail"], ConfigurationManager.AppSettings["MailPassword"]);
                        }

                        try
                        {
                            smtpClient.Send(PwReminderEmail);
                        }
                        catch (Exception exception)
                        {
                            response.Message = exception.Message;
                        }
                        response.IsSuccess = (String.IsNullOrEmpty(response.Message)) ? true : false;
                        response.Message = (String.IsNullOrEmpty(response.Message)) ? "We have sent your password on your registered email." : "";


                    }
                    else
                    {
                        response.LoginResult = LoginResultType.EmailNotFound;
                        response.Message = "Could not find an account with this email address.";
                    }

                }
            }

            catch (Exception ex)
            {
                response.LoginResult = LoginResultType.InvalidLogin;
                response.ResponseData = null;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<RoleDTO> GetRole()
        {
            List<RoleDTO> list = new List<RoleDTO>();
            try
            {

                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetRole");
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dtUser.Rows)
                    {
                        // if (dtUser != null && dtUser.Rows.Count > 0)
                        // {
                        RoleDTO role = new RoleDTO();

                        role.RoleId = Convert.ToInt32(dtUser.Rows[i]["RoleId"].ToString());
                        role.RoleName = dtUser.Rows[i]["RoleName"].ToString();
                        role.IsActive = Convert.ToBoolean(dtUser.Rows[i]["IsActive"].ToString());
                        // }
                        list.Add(role);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            { }
            return list;
        }
        public bool GetUserByEmail(string email)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                if ((!string.IsNullOrEmpty(email)))
                {
                    SqlParameter paramEmail = new SqlParameter("email", email);
                    DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetUserByEmail", new SqlParameter[] { paramEmail });

                    if (dtUser != null && dtUser.Rows.Count > 0)
                    {

                        response.IsSuccess = true;
                        response.Message = "Email exist.";

                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Email not exist.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Email not exist.";
            }
            return response.IsSuccess;
        }
        public List<DepartmentDTO> GetDepartments()
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            try
            {

                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetDepartments");
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dtUser.Rows)
                    {
                        // if (dtUser != null && dtUser.Rows.Count > 0)
                        // {
                        DepartmentDTO item = new DepartmentDTO();

                        item.DepartmentID = Convert.ToInt32(dtUser.Rows[i]["DepartmentID"].ToString());
                        item.Company = dtUser.Rows[i]["Company"].ToString();
                        item.Manager = dtUser.Rows[i]["Manager"].ToString();
                        item.Rate1 = dtUser.Rows[i]["Rate1"].ToString();
                        item.DefaultRate = dtUser.Rows[i]["DefaultRate"].ToString();
                        item.Name = dtUser.Rows[i]["Name"].ToString();
                        item.CreationDate = Convert.ToDateTime(dtUser.Rows[i]["CreationDate"].ToString());
                        item.ModifiedDate = Convert.ToDateTime(dtUser.Rows[i]["ModifiedDate"].ToString());
                        item.Creator = dtUser.Rows[i]["Creator"].ToString();
                        item.UniqueID = dtUser.Rows[i]["UniqueID"].ToString();
                        list.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            { }
            return list;
        }
        public List<JobSiteDTO> GetSites()
        {
            List<JobSiteDTO> list = new List<JobSiteDTO>();
            try
            {

                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetSite");
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dtUser.Rows)
                    {
                        // if (dtUser != null && dtUser.Rows.Count > 0)
                        // {
                        JobSiteDTO item = new JobSiteDTO();
                        item.Address = dtUser.Rows[i]["Address"].ToString();//
                        item.Coaxial = dtUser.Rows[i]["Coaxial"].ToString();//
                        item.CreationDate = dtUser.Rows[i]["CreationDate"].ToString();
                        item.Customer = dtUser.Rows[i]["Customer"].ToString();//
                        item.DeviceRegistration = dtUser.Rows[i]["DeviceRegistration"].ToString();//
                        item.Dispensers = dtUser.Rows[i]["Dispensers"].ToString();//
                        item.FacilityName = dtUser.Rows[i]["FacilityName"].ToString();//
                        item.MarketingManager = dtUser.Rows[i]["MarketingManager"].ToString();//
                        item.MeterCount = dtUser.Rows[i]["MeterCount"].ToString();//
                        item.ModifiedDate = dtUser.Rows[i]["ModifiedDate"].ToString();
                        item.PhoneNumber = dtUser.Rows[i]["PhoneNumber"].ToString();//
                        item.PicturesFiles = dtUser.Rows[i]["Pictures/Files"].ToString();//
                        item.RSM = dtUser.Rows[i]["RSM"].ToString();//
                        item.SiteEmail = dtUser.Rows[i]["SiteEmail"].ToString();//
                        item.StateID = dtUser.Rows[i]["StateID"].ToString();
                        item.Tanks = dtUser.Rows[i]["Tanks"].ToString();
                        item.UniqueID = dtUser.Rows[i]["UniqueID"].ToString();
                        item.WeightsAndMeasuresCertificateNumber = dtUser.Rows[i]["WeightsAndMeasuresCertificateNumber"].ToString();
                        item.WMCertificateImage = dtUser.Rows[i]["WMCertificateImage"].ToString();
                        list.Add(item);
                    }
                }

            }
            catch (Exception ex)
            { }
            return list;
        }

        public JobSiteDTO GetSitesBySiteID(int siteID)
        {
            JobSiteDTO item = new JobSiteDTO();
            try
            {
                SqlParameter param = new SqlParameter("SiteID", siteID);
                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetSiteBySiteID", new SqlParameter[] { param });
                if (dtUser != null && dtUser.Rows.Count > 0)
                {


                    item.Address = dtUser.Rows[0]["Address"].ToString();//
                    item.Coaxial = dtUser.Rows[0]["Coaxial"].ToString();//
                    item.CreationDate = dtUser.Rows[0]["CreationDate"].ToString();
                    item.Customer = dtUser.Rows[0]["Customer"].ToString();//
                    item.DeviceRegistration = dtUser.Rows[0]["DeviceRegistration"].ToString();//
                    item.Dispensers = dtUser.Rows[0]["Dispensers"].ToString();//
                    item.FacilityName = dtUser.Rows[0]["FacilityName"].ToString();//
                    item.MarketingManager = dtUser.Rows[0]["MarketingManager"].ToString();//
                    item.MeterCount = dtUser.Rows[0]["MeterCount"].ToString();//
                    item.ModifiedDate = dtUser.Rows[0]["ModifiedDate"].ToString();
                    item.PhoneNumber = dtUser.Rows[0]["PhoneNumber"].ToString();//
                    item.PicturesFiles = dtUser.Rows[0]["Pictures/Files"].ToString();//
                    item.RSM = dtUser.Rows[0]["RSM"].ToString();//
                    item.SiteEmail = dtUser.Rows[0]["SiteEmail"].ToString();//
                    item.StateID = dtUser.Rows[0]["StateID"].ToString();
                    item.Tanks = dtUser.Rows[0]["Tanks"].ToString();
                    item.UniqueID = dtUser.Rows[0]["UniqueID"].ToString();
                    item.WeightsAndMeasuresCertificateNumber = dtUser.Rows[0]["WeightsAndMeasuresCertificateNumber"].ToString();
                    item.WMCertificateImage = dtUser.Rows[0]["WMCertificateImage"].ToString();

                }


            }
            catch (Exception ex)
            { }
            return item;
        }
        public int InsertPasscode(PasscodeDTO data)
        {
            int passCodeId = 0;
          //  string passcode = System.Web.Security.Membership.GeneratePassword(6, 2);
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("SenderID", data.SenderID);
            sqlParams[1] = new SqlParameter("RecipientEmail", data.RecipientEmail);
            sqlParams[2] = new SqlParameter("PassCode",data.PassCode);
            sqlParams[3] = new SqlParameter("IsSignedUp", data.IsSignedUp);
            object objResult = SqlClientRMXProd.ExecuteScalar("udsp_InsertPasscodeInfo", sqlParams);
            if ((objResult != null) && (Int32.TryParse(objResult.ToString(), out passCodeId)))
            {
                return passCodeId;
            }
            return passCodeId;
        }

        public void UpdatePasscode(PasscodeDTO data)
        {

            SqlParameter[] sqlParams = new SqlParameter[2];
            sqlParams[0] = new SqlParameter("RecipientEmail", data.RecipientEmail);
            sqlParams[1] = new SqlParameter("IsSignedUp", data.IsSignedUp);
            object objResult = SqlClientRMXProd.ExecuteScalar("udsp_UpdatePasscodeInfo", sqlParams);

        }
        public PasscodeDTO GetPasscode()
        {
            PasscodeDTO list = new PasscodeDTO();
            try
            {


                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetPassCode");
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    list.PasscodeID = Convert.ToInt32(dtUser.Rows[0]["PasscodeID"].ToString());
                    list.PassCode = dtUser.Rows[0]["PassCode"].ToString();
                    list.RecipientEmail = dtUser.Rows[0]["RecipientEmail"].ToString();
                    list.SenderID = dtUser.Rows[0]["SenderID"].ToString();
                    list.IsSignedUp = Convert.ToBoolean(dtUser.Rows[0]["IsSignedUp"].ToString());
                }
            }
            catch (Exception ex)
            { }
            return list;
        }
        public List<PriorityDTO> GetPriority()
        {
            List<PriorityDTO> item = new List<PriorityDTO>();
            try
            {


                DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetPriority");
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dtUser.Rows)
                    {
                        // if (dtUser != null && dtUser.Rows.Count > 0)
                        // {
                        PriorityDTO list = new PriorityDTO();
                        list.CreatedDate = Convert.ToDateTime(dtUser.Rows[0]["CreatedDate"].ToString());
                        list.Creator = dtUser.Rows[0]["Creator"].ToString();
                        list.Description = dtUser.Rows[0]["Description"].ToString();
                        list.Level = dtUser.Rows[0]["Level"].ToString();
                        list.ModifiedDate = Convert.ToDateTime(dtUser.Rows[0]["ModifiedDate"].ToString());
                        list.Name = dtUser.Rows[0]["Name"].ToString();
                        list.NumberOfHoursDeadline = Convert.ToDecimal(dtUser.Rows[0]["NumberOfHoursDeadline"].ToString());
                        list.PriorityID = Convert.ToInt32(dtUser.Rows[0]["PriorityID"].ToString());
                        item.Add(list);
                    }
                }
            }
            catch (Exception ex)
            { }
            return item;
        }

        public int InsertWorkOrder(WorkOrderDTO data)
        {
            int workOrderId = 0;
            SqlParameter[] sqlParams = new SqlParameter[11];
            sqlParams[0] = new SqlParameter("CompletedDate", data.CompletedDate);
            sqlParams[1] = new SqlParameter("ContractorID", data.ContractorID);
            sqlParams[2] = new SqlParameter("DeadLineDate", data.DeadLineDate);
            sqlParams[3] = new SqlParameter("DepartmentID", data.DepartmentID);
            sqlParams[4] = new SqlParameter("DispatchedDate", data.DispatchedDate);
            sqlParams[5] = new SqlParameter("DispatchTo", data.DispatchTo);
            sqlParams[6] = new SqlParameter("PriorityID", data.PriorityID);
            sqlParams[7] = new SqlParameter("ProblemDescription", data.ProblemDescription);
            sqlParams[8] = new SqlParameter("ReceivedDate", data.ReceivedDate);
            sqlParams[9] = new SqlParameter("SiteID", data.SiteID);
            sqlParams[10] = new SqlParameter("WorkOrderStatus", ActivityStatusEnum.Unscheduled);
            object objResult = SqlClientRMXProd.ExecuteScalar("udsp_InsertWorkOrder", sqlParams);
            if ((objResult != null) && (Int32.TryParse(objResult.ToString(), out workOrderId)))
            {
                return workOrderId;
            }
            return workOrderId;
        }
        }
}