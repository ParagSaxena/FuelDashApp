﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FuelDashApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        private bool _operationInProgress;
        public bool OperationInProgress
        {
            get
            {
                return _operationInProgress;
            }
            set
            {
                if (_operationInProgress != value)
                {
                    _operationInProgress = value;
                    OnPropertyChanged(nameof(OperationInProgress));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
