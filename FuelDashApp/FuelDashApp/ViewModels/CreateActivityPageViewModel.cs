using FuelDashApp.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.ViewModels
{
    public class CreateActivityPageViewModel : BaseViewModel
    {
        private string _contactCenter;
        public string ContactCenter
        {
            get
            {
                return _contactCenter;
            }
            set
            {
                if (_contactCenter != value)
                {
                    _contactCenter = value;
                    OnPropertChanged(nameof(ContactCenter));
                }
            }
        }
        private string _referenceNumber;
        public string ReferenceNumber
        {
            get
            {
                return _referenceNumber;
            }
            set
            {
                if (_referenceNumber != value)
                {
                    _referenceNumber = value;
                    OnPropertChanged(nameof(ReferenceNumber));
                }
            }
        }
        private string _receivedDate;
        public string DateReceived
        {
            get
            {
                return _receivedDate;
            }
            set
            {
                if (_receivedDate != value)
                {
                    _receivedDate = value;
                    OnPropertChanged(nameof(DateReceived));
                }
            }
        }
        private string _deadlineDate;
        public string DeadlineDate
        {
            get
            {
                return _deadlineDate;
            }
            set
            {
                if (_deadlineDate != value)
                {
                    _deadlineDate = value;
                    OnPropertChanged(nameof(DeadlineDate));
                }
            }
        }
        private string _priority;
        public string Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertChanged(nameof(Priority));
                }
            }
        }
       
      
        private string _siteNumber;
        public string SiteNumber
        {
            get
            {
                return _siteNumber;
            }
            set
            {
                if (_siteNumber != value)
                {
                    _siteNumber = value;
                    OnPropertChanged(nameof(SiteNumber));
                }
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertChanged(nameof(Address));
                }
            }
        }

        private string _problemDescription;
        public string ProblemDescription
        {
            get
            {
                return _problemDescription;
            }
            set
            {
                if (_problemDescription != value)
                {
                    _problemDescription = value;
                    OnPropertChanged(nameof(ProblemDescription));
                }
            }
        }
        private string _department;
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    OnPropertChanged(nameof(Department));
                }
            }
        }

        public void ParseEamil(string email)
        {
            EmailParser.ParseEmail(email, out _referenceNumber, out _receivedDate, out _priority, out _deadlineDate, out _siteNumber, out _address, out _problemDescription);
            OnPropertChanged(nameof(ReferenceNumber));
            OnPropertChanged(nameof(DateReceived));
            OnPropertChanged(nameof(Priority));
            OnPropertChanged(nameof(DeadlineDate));
            OnPropertChanged(nameof(SiteNumber));
            OnPropertChanged(nameof(Address));
            OnPropertChanged(nameof(ProblemDescription));

        }
    }

}
