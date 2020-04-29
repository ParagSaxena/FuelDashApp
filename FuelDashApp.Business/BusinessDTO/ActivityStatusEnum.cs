namespace FuelDashApp.Business.BusinessDTO
{
    public class ActivityStatus
    {
      public  enum ActivityStatusEnum
        {
            Unscheduled=1,
            Dispatched=2,
            Review=3,
            Complete=4,
            Open=4,
            Cancel=5,
            ASAP=6,
            Scheduled=7,
            Hold=8
        }
    }
}