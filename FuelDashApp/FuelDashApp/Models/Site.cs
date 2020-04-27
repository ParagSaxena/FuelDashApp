using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Models
{

    public class SiteResponse : List<Site>
    {

    }

    public class Site
    {
        public string Address { get; set; }
        public string Coaxial { get; set; }
        public string Customer { get; set; }
        public string DeviceRegistration { get; set; }
        public string Dispensers { get; set; }
        public string PicturesFiles { get; set; }
        public string FacilityName { get; set; }
        public string MarketingManager { get; set; }
        public string MeterCount { get; set; }
        public string PhoneNumber { get; set; }
        public string RSM { get; set; }
        public string SiteEmail { get; set; }
        public string StateID { get; set; }
        public string Tanks { get; set; }
        public string WMCertificateImage { get; set; }
        public string WeightsAndMeasuresCertificateNumber { get; set; }
        public string CreationDate { get; set; }
        public string ModifiedDate { get; set; }
        public string UniqueID { get; set; }
    }

}
