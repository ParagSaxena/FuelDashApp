using FuelDashApp.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuelDashApp.ViewModels
{
    public class ForgotPasswordPageViewModel : BaseViewModel
    {
        public string _email;
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

        public async Task ForgotPasswordAsync()
        {
            if(OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            var result = await ForgotPasswordProvider.ChangePasswordAsync(Email);
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
