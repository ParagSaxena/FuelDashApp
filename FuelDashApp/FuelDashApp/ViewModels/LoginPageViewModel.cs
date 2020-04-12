using FuelDashApp.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
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
            var result = await LoginProvider.LoginAsync(Email, Password);
            if (result)
            {

            }
            else
            {

            }
            OperationInProgress = false;
        }
    }
}
