using FuelDashApp.Models;
using FuelDashApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.ViewModels
{
    public class SignupPageViewModel:BaseViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertChanged(nameof(FirstName));
                }
            }
        }
      
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertChanged(nameof(LastName));
                }
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertChanged(nameof(Email));
                }
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertChanged(nameof(Password));
                }
            }
        }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertChanged(nameof(ConfirmPassword));
                }
            }
        }

        private List<Role> _roles;
        public List<Role> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                    OnPropertChanged(nameof(Roles));
                }
            }
        }

        private Role _selectedRole;
        public Role SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                    OnPropertChanged(nameof(SelectedRole));
                }
            }
        }


        public async Task GetRolesAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            Roles = await RolesProvider.GetRolesAsync();
            SelectedRole = Roles?.FirstOrDefault();
            OperationInProgress = false;
        }

        public async Task RegisterAsync()
        {
           if(OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            var result =await SignupProvider.SignupAsync(FirstName, LastName, SelectedRole.RoleId, Email, Password, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            if(result)
            {

            }
            else
            {

            }
            OperationInProgress = false;
        }
    }
}
