using System;
using System.Collections.Specialized;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void BtnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new NameValueCollection
                {
                    {"brand", TxtMarca.Text},
                    {"model", TxtModelo.Text},
                    {"year", TxtAnio.Text},
                    {"plate", TxtPlaca.Text},
                    {"color", TxtColor.Text}
                };

                cliente.UploadValues("http://192.168.31.247:81/projects/semana5/methods.php", "POST", parametros);
                DisplayAlert("Alerta!", "Dato ingresado correctamente", "Aceptar");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Aceptar");
            }
        }

        private void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}