using FuelDashApp.Models;
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
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public async Task<BaseResponse> ForgotPasswordAsync()
        {
            //if(OperationInProgress)
            //{
            //    return ;
            //}
            OperationInProgress = true;
            LoginPageViewModel login = new LoginPageViewModel();
            login.Email = Email;
            var result = await new APIData().PostData<BaseResponse>("User/ForgotPassword", login, false);

           // var result = await ForgotPasswordProvider.ChangePasswordAsync(Email);
            if (result!=null && result.LoginResult==0)
            {
               
            }
            else
            {

            }
            OperationInProgress = false;
            return result;
        }
    }
}
