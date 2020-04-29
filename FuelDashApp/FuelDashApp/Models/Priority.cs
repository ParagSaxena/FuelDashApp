using System;
using System.Collections.Generic;

namespace FuelDashApp.Models
{
    public class Priorities : List<Priority>
    {
    }

    public class Priority
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public double NumberOfHoursDeadline { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Creator { get; set; }
        public int PriorityID { get; set; }
    }

}
