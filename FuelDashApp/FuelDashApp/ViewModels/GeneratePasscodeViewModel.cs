﻿using FuelDashApp.Models;
using FuelDashApp.Providers;
using FuelDashApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelDashApp.ViewModels
{
    public class GeneratePasscodeViewModel : BaseViewModel
    {
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
                    OnPropertyChanged(nameof(Roles));
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
                    OnPropertyChanged(nameof(SelectedRole));
                }
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
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
        public async Task GetRolesAsync()
        {
            if (OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            // Roles = await new APIData().GetListData<Role>("User/GetRole", false);

            var Rolelist = await RolesProvider.GetRolesAsync();
            Roles = Rolelist.Where(i => i.RoleName != "Admin").ToList();
            SelectedRole = Roles?.FirstOrDefault();
            OperationInProgress = false;
        }
        public async Task IsAlreadySendPasscode()
        {
            PassCodeData = await new APIData().GetListData<PasscodeModel>("User/GetPasscode?email=" + Email, false);

        }
        public async Task GeneratePasscode()
        {
            if (OperationInProgress)
            {
                return;
            }
            OperationInProgress = true;
            ValidateForm();
            if (IsValid)
            {
                PasscodeModel code = new PasscodeModel();
                code.PasscodeID = 0;
                code.PassCode = null;
                code.RoleId = SelectedRole.RoleId;
                code.RecipientEmail = Email;
                code.SenderID = App.UserId;
                code.IsSignedUp = false;
                code.MailMessage = Message;
                code.SenderEmail = App.UserEmail;
                code.CreationDate = DateTime.Now;
                code.ModifiedDate = DateTime.Now;
                var result = await new APIData().PostData<int>("User/InsertPasscodeData", code, false);

                if (result > 0)
                {

                }
            }
            OperationInProgress = false;
        }

        private async void ValidateForm()
        {
            IsValid = true;
            var Toast = DependencyService.Get<IMessage>();
            if (SelectedRole == null || SelectedRole.RoleId <= 0)
            {
                Toast.LongAlert("Role is required."); IsValid = false; return;
            }
            if (String.IsNullOrEmpty(Email))
            {
                Toast.LongAlert("Email is required."); IsValid = false; return;
            }
            if (!Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                Toast.LongAlert("Invalid email address."); IsValid = false; return;
            }
            await IsAlreadySendPasscode();
            if (PassCodeData != null)
            {
                if (PassCodeData.Where(i => i.SenderID == App.UserId).FirstOrDefault() != null)
                {
                    if (PassCodeData.Where(i => i.SenderID == App.UserId).FirstOrDefault().SenderID == App.UserId &&
                        PassCodeData.Where(i => i.SenderID == App.UserId).FirstOrDefault().IsSignedUp)
                    {
                        string msg = "This " + SelectedRole.RoleName + " is already a member od FuelDash portal.";
                        Toast.LongAlert(msg); IsValid = false; return;
                    }

                }

            }
        }
    }
}
