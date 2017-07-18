using ClicHood.Models;
using ClicHood.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClicHood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Usuario vendedor = new Usuario();
            UsuarioServicio servicio = new UsuarioServicio();
            Respuesta result = new Respuesta();

            if (!string.IsNullOrEmpty(nombre.Text)
                && !string.IsNullOrEmpty(apellidos.Text)
                && !string.IsNullOrEmpty(email.Text)
                && !string.IsNullOrEmpty(password.Text))
            {
                vendedor.Nombre = nombre.Text;
                vendedor.Apellidos = apellidos.Text;
                vendedor.Email = email.Text;
                vendedor.Password = password.Text;

                loading.IsRunning = true;

                var response = await servicio.RegistrarVendedor(vendedor);

                loading.IsRunning = false;

                result = JsonConvert.DeserializeObject<Respuesta>(response.Content.ReadAsStringAsync().Result);

                if(result.codeResponse == 200)
                {
                    await DisplayAlert("Información", "Registrado con éxito", "Aceptar");

                    nombre.Text = string.Empty;
                    apellidos.Text = string.Empty;
                    email.Text = string.Empty;
                    password.Text = string.Empty;
                    return;
                } else
                {
                    await DisplayAlert("Error", "Hubo un error al registrar sus datos, intente de nuevo", "Aceptar");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Error", "No puede dejar campos vacíos", "Aceptar");
                return;
            }

        }
    }
}
