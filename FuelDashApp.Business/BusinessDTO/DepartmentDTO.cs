using System;

namespace FuelDashApp.Business.BusinessDTO
{
    public class DepartmentDTO
    {
        public int DepartmentID{ get; set; }
        public string Company{ get; set; }
        public string Manager{ get; set; }
        public string Rate1 { get; set; }
        public string DefaultRate { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Creator { get; set; }
        public string UniqueID { get; set; }
       
    }
}