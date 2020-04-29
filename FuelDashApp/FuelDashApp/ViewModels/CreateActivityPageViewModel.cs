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
        private DateTime _receivedDate = DateTime.Now;
        public DateTime DateReceived
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
        private DateTime _deadlineDate = DateTime.Now;
        public DateTime DeadlineDate
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


        private List<Site> _sites;
        public List<Site> Sites
        {
            get
            {
                return _sites;
            }
            set
            {
                if (_sites != value)
                {
                    _sites = value;
                    OnPropertyChanged(nameof(Sites));
                }
            }
        }

        private Site _selectedSite;
        public Site SelectedSite
        {
            get
            {
                return _selectedSite;
            }
            set
            {
                if (_selectedSite != value)
                {
                    _selectedSite = value;
                    Address = _selectedSite?.Address ?? string.Empty;
                    OnPropertyChanged(nameof(SelectedSite));
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
            OperationInProgress = true;
            Departments = await DepartmentsProvider.GetDepartmentsAsync();
            SelectedDeparment = Departments?.FirstOrDefault();
            OperationInProgress = false;
        }

        public async Task GetPrioritiesAsync()
        {
            OperationInProgress = true;
            Priorities = await PrioritiesProvider.GetPrioritiesAsync();
            SelectedPriority = Priorities?.FirstOrDefault();
            OperationInProgress = false;
        }

        public async Task GetSitesAsync()
        {
            OperationInProgress = true;
            Sites = await SitesProvider.GetSitesAsync();
            SelectedSite = Sites?.FirstOrDefault();
            OperationInProgress = false;
        }

        public async Task CreateWorkOrderAsync()
        {
            if(OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            var result =await WorkOrderProvider.CreateWorkOrderAsync(0, 
                DeadlineDate,
                -1,
                DateTime.Now,
                App.UserId,
                DateReceived,
                DateTime.Now,
                -1,
                SelectedPriority.PriorityID,
                ProblemDescription,
                ActivityStatusEnum.Open.ToString());
            OperationInProgress = false;
        }
    }

}
