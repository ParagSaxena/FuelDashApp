using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDashApp.Business.BusinessDTO
{
    public class ResponseDTO
    {
        public LoginResultType LoginResult { get; set; }
        public string Message { get; set; }
        public object ResponseData { get; set; }
        public bool IsSuccess { get; set; }
    }
    public enum LoginResultType
    {
        Success = 0,
        TooManyUsers = 1,
        InvalidLogin = 2,
        EmailNotFound = 3,
        NullPassword = 4,
        Unknown = 5
    }
}