using System;

namespace FuelDashApp.Models
{
    public class PasscodeModel
    {
        public int PasscodeID { get; set; }
        public int SenderID { get; set; }
        public int RoleId { get; set; }
        public string RecipientEmail { get; set; }
        public string PassCode { get; set; }
        public bool IsSignedUp { get; set; }
        public string SenderEmail { get; set; }
        public string MailMessage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
