using System;
using System.Collections.Generic;

namespace FuelDashApp.Models
{
    public class Departments : List<Department>
    {
    }

    public class Department
    {
        public int DepartmentID { get; set; }
        public string Company { get; set; }
        public string Manager { get; set; }
        public string Rate1 { get; set; }
        public string DefaultRate { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Creator { get; set; }
        public string UniqueID { get; set; }
    }
}
