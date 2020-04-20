using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDashApp.Business.BusinessDTO
{
    public class PasscodeDTO
    {
        public int PasscodeID { get; set; }
        public string SenderID{ get; set; }
        public string RecipientEmail { get; set; }
        public string PassCode { get; set; }
        public bool IsSignedUp { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}