using ClicHood.Models;
using ClicHood.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClicHood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private UsuarioServicio _servicio;
        private Respuesta _response;

        public LoginPage()
        {
            InitializeComponent();
            _servicio = new UsuarioServicio();
            _response = new Respuesta();
        }

        private async void btnAcceso_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
                loading.IsRunning = true;
                loading.IsVisible = true;

                var response = await _servicio.Ingreso(email.Text, password.Text);
                _response = JsonConvert.DeserializeObject<Respuesta>(response.Content.ReadAsStringAsync().Result);

                loading.IsRunning = false;
                loading.IsVisible = false;

                if (_response.codeResponse == 200)
                {
                    await Navigation.PushAsync(new HomePage(), true);
                }
                else
                {
                    await DisplayAlert("Error", "Datos de acceso incorrectos", "Aceptar");
                    password.Text = string.Empty;
                    return;
                }

            }
            else
            {
                await DisplayAlert("Error", "Los campos no deben estar vacíos", "Aceptar");

                if (string.IsNullOrEmpty(email.Text))
                    email.Focus();
                if (string.IsNullOrEmpty(password.Text))
                    password.Focus();

                return;
            }
        }
    }
}
