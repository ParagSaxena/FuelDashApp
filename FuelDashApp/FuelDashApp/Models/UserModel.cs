using System;

namespace FuelDashApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
      //  public int RoleID { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }//
        public string HomeAddress { get; set; }//
        public string WMTechID { get; set; }//
        public string ClockedIn { get; set; }//
        public string Company { get; set; }//
        public string Department { get; set; }//
        public double LaborRateSell { get; set; }//
        public double LaborRateCost { get; set; }//
        public string LastName { get; set; }//
        public string CurrentLocation { get; set; }//
        public string PayRate { get; set; }//
        public float PhoneNumber { get; set; }//
        public string ProfilePicture { get; set; }//
        public string TimeSheets { get; set; }//
        public string Title { get; set; }//
        public string Truck { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
        public string UniqueID { get; set; }


    }
}
