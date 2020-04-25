using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class WorkOrderProvider
    {
        public  static async Task<bool> CreateWorkOrderAsync(int siteId,
            DateTime deadlineDate,
            int departmentId,
            DateTime completedDate,
            int contractorId,
            DateTime receivedDate,
            DateTime dispatchedDate,
            int dispatchTo,
            int priorityId,
            string problemDescription,
            string workOrderStatus)
        {

            var request = new WorkOrderRequest()
            {
                CompletedDate=completedDate,
                ContractorID=contractorId,
                DeadLineDate=deadlineDate,
                DepartmentID=departmentId,
                DispatchedDate=dispatchedDate,
                DispatchTo = dispatchTo,
                PriorityID=priorityId,
                ProblemDescription=problemDescription,
                ReceivedDate=receivedDate,
                SiteID = siteId,
                WorkOrderID = 0,//check this????
                WorkOrderStatus=workOrderStatus,
            };

            var response = await new APIData().PostData<BaseResponse>(APIUrlConstant.CreateWorkOrderApi, request);
            return false;
        }
    }
}
