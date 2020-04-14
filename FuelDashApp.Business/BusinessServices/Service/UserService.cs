using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using FuelDashApp.Business.BusinessDTO;
using FuelDashApp.Business.Sql;
using Headway.Recruiting;

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
            //sqlParams[0] = new SqlParameter("UserId", userData.UserId);
            sqlParams[1] = new SqlParameter("RoleId", userData.RoleId);
            sqlParams[2] = new SqlParameter("Password", userData.Password);
            sqlParams[3] = new SqlParameter("IsActive", userData.IsActive);
            sqlParams[4] = new SqlParameter("FirstName", userData.FirstName);
            sqlParams[5] = new SqlParameter("HomeAddress", userData.HomeAddress);
            sqlParams[6] = new SqlParameter("WMTechID", userData.WMTechID);
            sqlParams[7] = new SqlParameter("ClockedIn", userData.ClockedIn);
            sqlParams[8] = new SqlParameter("Company", userData.Company);
            sqlParams[9] = new SqlParameter("Department", userData.Department);
            sqlParams[10] = new SqlParameter("LaborRateCost", userData.LaborRateCost);
            sqlParams[11] = new SqlParameter("LaborRateSell", userData.LaborRateSell);
            sqlParams[12] = new SqlParameter("LastName", userData.LastName);
            sqlParams[13] = new SqlParameter("CurrentLocation", userData.CurrentLocation);
            sqlParams[14] = new SqlParameter("PayRate", userData.PayRate);
            sqlParams[15] = new SqlParameter("PhoneNumber", userData.PhoneNumber);
            sqlParams[16] = new SqlParameter("ProfilePicture", userData.ProfilePicture);
            sqlParams[17] = new SqlParameter("TimeSheets", userData.TimeSheets);
            sqlParams[18] = new SqlParameter("Title", userData.Title);
            sqlParams[19] = new SqlParameter("Truck", userData.Truck);
            sqlParams[20] = new SqlParameter("Type", userData.Type);
           // sqlParams[21] = new SqlParameter("CreationDate", userData.CreationDate);
            //sqlParams[22] = new SqlParameter("ModifiedDate", userData.ModifiedDate);
            sqlParams[21] = new SqlParameter("Email", userData.Email);
            sqlParams[0] = new SqlParameter("UniqueID", userData.UniqueID);
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
    }
}