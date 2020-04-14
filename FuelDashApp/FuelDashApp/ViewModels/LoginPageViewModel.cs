using FuelDashApp.Providers;
using FuelDashApp.Services;
using System;
using System.Collections.Generic;
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
                OnPropertChanged(nameof(IsValid));
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
                var result = await LoginProvider.LoginAsync(Email, Password);
                if (result)
                {

                }
                else
                {

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
