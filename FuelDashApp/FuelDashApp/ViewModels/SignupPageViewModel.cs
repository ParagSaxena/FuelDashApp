using FuelDashApp.Models;
using FuelDashApp.Providers;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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
                OnPropertyChanged(nameof(Message));
            }
        }
        private bool _isMailExist;
        public bool IsMailExist
        {
            get { return _isMailExist; }
            set
            {
                _isMailExist = value;
                OnPropertyChanged(nameof(IsMailExist));
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
                OnPropertyChanged(nameof(IsValid));
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
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        private List<PasscodeModel> _passcode;
        public List<PasscodeModel> PassCodeData
        {
            get
            {
                return _passcode;
            }
            set
            {
                if (_passcode != value)
                {
                    _passcode = value;
                    OnPropertyChanged(nameof(PassCodeData));
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
                    OnPropertyChanged(nameof(LastName));
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
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        private string _passCode;
        public string Passcode
        {
            get
            {
                return _passCode;
            }
            set
            {
                if (_passCode != value)
                {
                    _passCode = value;
                    OnPropertyChanged(nameof(Passcode));
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
                    OnPropertyChanged(nameof(Password));
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
                    OnPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }


        public SignupPageViewModel()
        {
        }

        public async Task IsEmailExsitAsync()
        {
            IsMailExist = false;
            var data = await new APIData().GetData<DataTable>("User/GetUserByEmail?email=" + Email, false);
            if (data != null && data.DataSet!=null)
            {
                IsMailExist = true;
            }
        }
        public async Task IsCorrectPassCodeAsync()
        {
            PassCodeData = await new APIData().GetListData<PasscodeModel>("User/GetPasscode?email=" + Email, false);

        }

        public async Task RegisterAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
          //  ValidateForm();
            if (IsValid)
            {

                OperationInProgress = true;
                UserModel _user = new UserModel();
                _user.FirstName = FirstName;
                _user.LastName = LastName;
               // _user.RoleID = PassCodeData.RoleId;
                _user.Email = Email;
                _user.Password = Password;
                var result = await new APIData().PostData<int>("User/Registration", _user, false);

                //var result = await SignupProvider.SignupAsync(_user);
                //            var result =await SignupProvider.SignupAsync(FirstName, LastName, SelectedRole.RoleId, Email, Password, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                if (result > 0)
                {
                    PasscodeModel data = new PasscodeModel();
                    data.RecipientEmail = Email;
                    data.IsSignedUp = true;
                    await new APIData().PostData<int>("User/UpdatePasscode", data, false);
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

    }
}
