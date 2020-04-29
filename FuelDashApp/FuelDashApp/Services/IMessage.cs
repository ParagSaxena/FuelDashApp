﻿namespace FuelDashApp.Services
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
        string GetPath();
    }
}
