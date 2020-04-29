using FuelDashApp.Services;

namespace FuelDashApp
{
    public class Constants
    {
        public const string Host = "http://184.164.128.36/api/User";

        public static string GetDataApi = $"{Host}/GetData";
        public static string UserLoginApi = $"{Host}/UserLogin";
        public static string ForgotPasswordApi = $"{Host}/ForgotPassword";
        public static string UserRegistrationApi = $"{Host}/Registration";
        public static string GetRolesApi = $"{Host}/GetRole";

        public static HttpService _httpSerivceInstance;

        public static HttpService HttpSerivceInstance
        {
            get
            {
                if(_httpSerivceInstance == null)
                {
                    _httpSerivceInstance = new HttpService();
                }
                return _httpSerivceInstance;
            }
        }
    }
}
