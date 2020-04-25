using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Models
{

    public class WorkOrderRequest
    {
        public int WorkOrderID { get; set; }
        public int SiteID { get; set; }
        public DateTime DeadLineDate { get; set; }
        public int DepartmentID { get; set; }
        public DateTime CompletedDate { get; set; }
        public int ContractorID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime DispatchedDate { get; set; }
        public int DispatchTo { get; set; }
        public int PriorityID { get; set; }
        public string ProblemDescription { get; set; }
        public string WorkOrderStatus { get; set; }
    }
}
