using FuelDashApp.Models;
using FuelDashApp.Providers;
using FuelDashApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelDashApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private bool _isValid { get; set; }

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
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
        private bool _isPopupButtonEnable;
        public bool IsPopupButtonEnable
        {
            get { return _isPopupButtonEnable; }
            set
            {
                _isPopupButtonEnable = value;
                OnPropertyChanged();
            }
        }
        public LoginPageViewModel()
        {
            App.IsPopupButtonEnable = true;
            IsPopupButtonEnable = App.IsPopupButtonEnable;

        }

        public async Task LoginAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            ValidateForm();
            if (IsValid)
            {
                LoginRequest loginData = new LoginRequest();
                loginData.Email = Email;
                loginData.Password = Password;
                var result = await new APIData().GetData<bool>("User/UserLogin?email="+Email+"&&password="+Password, true);
              //  var result = await LoginProvider.LoginAsync(Email, Password);
                if (result)
                {
                  var  userdata = await new APIData().GetData<DataTable>("User/GetUserByEmail?email=" + Email, false);
                    if(userdata!=null && userdata.DataSet!=null)
                    {
                        App.UserEmail = Email;
                        App.UserId =Convert.ToInt32(userdata.Rows[0]["UserID"].ToString());
                    }
                }
                else
                {
                    IsValid = false;
                }
            }
            OperationInProgress = false;
        }

        private void ValidateForm()
        {
            IsValid = true;
            var Toast = DependencyService.Get<IMessage>();
            if (String.IsNullOrEmpty(Email))
            {
                Toast.LongAlert("Email is required."); IsValid = false; return;
            }
            if (!Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                Toast.LongAlert("Invalid email address."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(Password))
            {
                Toast.LongAlert("Password is required."); IsValid = false; return;
            }
        }
    }
}
