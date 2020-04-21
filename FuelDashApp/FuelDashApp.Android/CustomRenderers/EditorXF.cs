using Xamarin.Forms;

namespace FuelDashApp.Droid.CustomRenderers
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