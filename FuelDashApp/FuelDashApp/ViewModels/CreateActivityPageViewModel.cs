using FuelDashApp.Helper;
using FuelDashApp.Models;
using FuelDashApp.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    OnPropertyChanged(nameof(ContactCenter));
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
                    OnPropertyChanged(nameof(ReferenceNumber));
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
                    OnPropertyChanged(nameof(DateReceived));
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
                    OnPropertyChanged(nameof(DeadlineDate));
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
                    OnPropertyChanged(nameof(Priority));
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
                    OnPropertyChanged(nameof(SiteNumber));
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
                    OnPropertyChanged(nameof(Address));
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
                    OnPropertyChanged(nameof(ProblemDescription));
                }
            }
        }
        private List<Department> _departments;
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged(nameof(Departments));
                }
            }
        }

        private Department _selectedDepartment;
        public Department SelectedDeparment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                if(_selectedDepartment!=value)
                {
                    _selectedDepartment = value;
                    OnPropertyChanged(nameof(SelectedDeparment));
                }
            }
        }

        private List<Priority> _priorities;
        public List<Priority> Priorities
        {
            get
            {
                return _priorities;
            }
            set
            {
                if (_priorities != value)
                {
                    _priorities = value;
                    OnPropertyChanged(nameof(Priorities));
                }
            }
        }

        private Priority _selectedPriority;
        public Priority SelectedPriority
        {
            get
            {
                return _selectedPriority;
            }
            set
            {
                if (_selectedPriority != value)
                {
                    _selectedPriority = value;
                    OnPropertyChanged(nameof(SelectedPriority));
                }
            }
        }


        public void ParseEamil(string email)
        {
            EmailParser.ParseEmail(email, out _referenceNumber, out _receivedDate, out _priority, out _deadlineDate, out _siteNumber, out _address, out _problemDescription);
            OnPropertyChanged(nameof(ReferenceNumber));
            OnPropertyChanged(nameof(DateReceived));
            OnPropertyChanged(nameof(Priority));
            OnPropertyChanged(nameof(DeadlineDate));
            OnPropertyChanged(nameof(SiteNumber));
            OnPropertyChanged(nameof(Address));
            OnPropertyChanged(nameof(ProblemDescription));

        }

        public async Task GetDepartmentsAsync()
        {
            Departments = await DepartmentsProvider.GetDepartmentsAsync();
            SelectedDeparment = Departments?.FirstOrDefault();
        }

        public async Task GetPrioritiesAsync()
        {
            Priorities = await PrioritiesProvider.GetPrioritiesAsync();
            SelectedPriority = Priorities?.FirstOrDefault();
        }
    }

}
