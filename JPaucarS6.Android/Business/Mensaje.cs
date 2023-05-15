using Android.App;
using Android.Widget;
using JPaucarS6.Droid.Business;
using JPaucarS6.IBusiness;

[assembly: Xamarin.Forms.Dependency(typeof(Mensaje))] //Se considerará el archivo al momento de compilar el app

namespace JPaucarS6.Droid.Business
{
    public class Mensaje : IMensaje
    {
        public void longAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show(); //5 segundos
        }

        public void shorAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show(); //3 segundos
        }
    }
}