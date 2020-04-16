using FuelDashApp.Models;
using FuelDashApp.Providers;
using FuelDashApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelDashApp.ViewModels
{
    public class SignupPageViewModel : BaseViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertChanged(nameof(Message));
            }
        }
        private bool _isMailExist;
        public bool IsMailExist
        {
            get { return _isMailExist; }
            set
            {
                _isMailExist = value;
                OnPropertChanged(nameof(IsMailExist));
            }
        }
        private bool _isValid { get; set; }
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertChanged(nameof(IsValid));
            }
        }
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

        public SignupPageViewModel(string name , string email)
        {
            FirstName = name;
            Email = email;
        }
        public async Task GetRolesAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
         // Roles = await new APIData().GetListData<Role>("User/GetRole", false);

            Roles = await RolesProvider.GetRolesAsync();
            SelectedRole = Roles?.FirstOrDefault();
            OperationInProgress = false;
        }
        public async Task IsEmailExsitAsync()
        {
            ///IsMailExist = false;
            IsMailExist = await new APIData().GetData<bool>("User/GetUserByEmail?email="+Email, false);

        }

        public async Task RegisterAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
            ValidateForm();
            if (IsValid)
            {
               
                OperationInProgress = true;
                UserModel _user = new UserModel();
                _user.FirstName = FirstName;
                _user.LastName = LastName;
                _user.RoleID = SelectedRole.RoleId;
                _user.Email = Email;
                _user.Password = Password;
                var result = await new APIData().PostData<int>("User/Registration",_user, false);

                //var result = await SignupProvider.SignupAsync(_user);
                //            var result =await SignupProvider.SignupAsync(FirstName, LastName, SelectedRole.RoleId, Email, Password, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                if (result>0)
                {
                    Message = "Welcome to Fuel Dash.";
                    App.UserId = result;
                }
                else
                {
                    Message = "Sign up failed.";
                }
                OperationInProgress = false;
            }
        }
        private async void ValidateForm()
        {
            IsValid = true;
            var Toast = DependencyService.Get<IMessage>();
            if (SelectedRole==null ||SelectedRole.RoleId<=0)
            {
                Toast.LongAlert("Role is required."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(FirstName))
            {
                Toast.LongAlert("First name is required."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(LastName))
            {
                Toast.LongAlert("Last name is required."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(Email))
            {
                Toast.LongAlert("Email is required."); IsValid = false; return;
            }
            await IsEmailExsitAsync();
            if (IsMailExist)
            {
                Toast.LongAlert("Email already exist."); IsValid = false; return;
            }
            if (!Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                Toast.LongAlert("Invalid email address."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(Password))
            {
                Toast.LongAlert("Password is required."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(ConfirmPassword))
            {
                Toast.LongAlert("Confirm password is required."); IsValid = false; return;
            }
            if (Password != ConfirmPassword)
            {
                Toast.LongAlert("Confirm password is not matched."); IsValid = false; return;
            }
        }
    }
}
