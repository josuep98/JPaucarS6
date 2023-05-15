using JPaucarS6.Clases;
using JPaucarS6.IBusiness;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizacion : ContentPage
    {
        private const string Url = "http://192.168.31.247:81/projects/semana5/methods.php";

        public Actualizacion(VehicleResponse vehicle)
        {
            InitializeComponent();
            TxtId.Text = Convert.ToString(vehicle.Id);
            TxtAnio.Text = Convert.ToString(vehicle.Year);
            TxtColor.Text = vehicle.Color;
            TxtMarca.Text = vehicle.Brand;
            TxtModelo.Text = vehicle.Model;
            TxtPlaca.Text = vehicle.Plate;
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string urlRequest = $"{Url}?id={TxtId.Text}";
            var response = await client.DeleteAsync(urlRequest);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito!", "Se eliminó el vehículo", "Aceptar");
                await Navigation.PushAsync(new MainPage());
            }
            else
                await DisplayAlert("Error!", "No se pudo eliminar el vehículo", "Aceptar");

        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var content = new VehicleRequest
            {
                id = Convert.ToInt32(TxtId.Text),
                brand = TxtMarca.Text,
                model = TxtModelo.Text,
                year = Convert.ToInt32(TxtAnio.Text),
                plate = TxtPlaca.Text,
                color = TxtColor.Text,
            };
            /*string jsonData = JsonConvert.SerializeObject(content);
            var vehicleRequest = new StringContent(jsonData, Encoding.UTF8, "application/json");*/
            string urlRequest = $"{Url}?id={content.id}&brand={content.brand}&model={content.model}&year={content.year}&plate={content.plate}&color={content.color}";
            var response = await client.PutAsync(urlRequest, null); //vehicleRequest si usamos content en el servicio php
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();
                await DisplayAlert("Éxito!", "Se actualizó la información", "Aceptar");
                await Navigation.PushAsync(new MainPage());
            }
            else
                await DisplayAlert("Error!", "No se pudo actualizar la información", "Aceptar");

        }
    }
}