using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.Helper.Interface
{
    interface IMediaService
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}
