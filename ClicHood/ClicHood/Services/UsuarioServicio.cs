using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClicHood.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ClicHood.Services
{
    public class UsuarioServicio
    {
        private HttpClient _client;

        public UsuarioServicio()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost");
        }

        public async Task<HttpResponseMessage> Ingreso(string email, string password)
        {
            Usuario vendedor = new Usuario();
            vendedor.Email = email;
            vendedor.Password = password;
            var json = JsonConvert.SerializeObject(vendedor);

            HttpContent content = new StringContent(json);
            
            string url = string.Format("/Servicios/ClicHood/Acceso/ingreso");
            var response = await _client.PostAsync(url, content);

            return response;
        }

        public Usuario ObtenerUsusario()
        {
            Usuario vendedor = new Usuario();

            vendedor.Nombre = "Alejandro";
            vendedor.Apellidos = "Aguilar";
            vendedor.Email = "kainraziellok@gmail.com";

            return vendedor;
        }

        public async Task<HttpResponseMessage> RegistrarVendedor(Usuario vendedor)
        {
            var json = JsonConvert.SerializeObject(vendedor);
            HttpContent content = new StringContent(json);
            string url = string.Format("/Servicios/ClicHood/vendedores");
            var response = await _client.PostAsync(url, content);

            return response;
        }
    }
}
