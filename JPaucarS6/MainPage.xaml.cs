using JPaucarS6.Clases;
using JPaucarS6.IBusiness;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;

namespace JPaucarS6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.31.247:81/projects/semana5/methods.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<VehicleResponse> _post;

        public MainPage()
        {
            InitializeComponent();
            ConsultarDatos();
        }

        private void Registro_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Bienvenido";
            DependencyService.Get<IMensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Registro());
        }

        private void BtnGet_Clicked(object sender, EventArgs e)
        {
            ConsultarDatos();
        }

        private async void ConsultarDatos()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<VehicleResponse> response = JsonConvert.DeserializeObject<List<VehicleResponse>>(content);
                _post = new ObservableCollection<VehicleResponse>(response);

                ListaVehiculos.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("No se pudo obtener los datos", ex.Message, "Aceptar");
            }
        }

        private void ListaVehiculos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vehicleData = (VehicleResponse)e.SelectedItem;
            //var id = Convert.ToInt32(vehicleData.Id.ToString());
            try
            {
                Navigation.PushAsync(new Actualizacion(vehicleData));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
