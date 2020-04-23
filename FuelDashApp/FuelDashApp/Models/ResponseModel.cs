using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Models
{
    public class ResponseModel
    {
        public int LoginResult { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
