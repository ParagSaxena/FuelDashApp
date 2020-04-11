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
    public class UserService :Base,  IUserService
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
                    // SqlParameter paramPassword = new SqlParameter("Password", password);
                    DataTable dtUser = SqlClientRMXProd.ExecuteDataTable("udsp_GetUserByEmail", new SqlParameter[] { paramEmail });
                    BusinessDTO.User userData = new BusinessDTO.User();
                    if (dtUser != null && dtUser.Rows.Count > 0 && password == dtUser.Rows[0]["Password"].ToString())
                    {
                        response.LoginResult = LoginResultType.Success;
                    }
                    else
                    {
                        response.LoginResult = LoginResultType.InvalidLogin;
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
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("RoleId", userData.RoleId);
            sqlParams[1] = new SqlParameter("FirstName", userData.FirstName);
            sqlParams[2] = new SqlParameter("LastName", userData.LastName);
            sqlParams[3] = new SqlParameter("Password", userData.Password);
            sqlParams[4] = new SqlParameter("Email", userData.Email);
            sqlParams[5] = new SqlParameter("PhoneNumber", userData.PhoneNumber);
            sqlParams[6] = new SqlParameter("Address", userData.Address);
            sqlParams[7] = new SqlParameter("City", userData.City);
            sqlParams[8] = new SqlParameter("State", userData.State);
            sqlParams[9] = new SqlParameter("Zip", userData.Zip);
            sqlParams[10] = new SqlParameter("ProfileImage", userData.ProfileImage);
            sqlParams[11] = new SqlParameter("IsActive", userData.IsActive);
            object objResult =SqlClientRMXProd.ExecuteScalar("udsp_User_Insert", sqlParams);
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
                            From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"])
                        };
                        // email to address
                        PwReminderEmail.To.Add(email);
                        // email subject
                        PwReminderEmail.Subject = ConfigurationManager.AppSettings["MailSubject"];
                        // email body
                        //PwReminderEmail.Body = emailSettings.Body;
                        string body = "<p>You were trying to retrive your password from FuelDash app. <br/><br/>Your password is " + dtUser.Rows[0]["Password"].ToString() + ">  </p>";
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
                    RoleDTO role = new RoleDTO();
                    foreach (RoleDTO obj in dtUser.Rows)
                    {
                        role.RoleId = obj.RoleId;
                        role.RoleName = obj.RoleName;
                        role.IsActive = obj.IsActive;
                    }
                    list.Add(role);
                }
            }
            catch(Exception ex)
            { }
            return list;
        }
    }
}