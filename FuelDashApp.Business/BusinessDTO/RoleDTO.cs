using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDashApp.Business.BusinessDTO
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}