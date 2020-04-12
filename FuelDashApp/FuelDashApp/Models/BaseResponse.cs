using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Models
{
    public class BaseResponse
    {
        public int LoginResult { get; set; }
        public string Message { get; set; }
        public Responsedata ResponseData { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class Responsedata
    {
    }
}
