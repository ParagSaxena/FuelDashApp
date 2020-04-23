using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FuelDashApp.Views.CustomControls
{
    public class EditorXF : Editor
    {
        public EditorXF()
        {
            this.TextChanged += (sender, e) =>
            {
                this.InvalidateMeasure();
            };
        }
    }
}
