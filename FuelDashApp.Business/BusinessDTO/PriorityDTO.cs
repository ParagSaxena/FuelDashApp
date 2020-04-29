using System;

namespace FuelDashApp.Business.BusinessDTO
{
    public class PriorityDTO
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public decimal NumberOfHoursDeadline { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Creator { get; set; }
        public int PriorityID { get; set; }
    }
}