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
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://alejandro-aguilar.com")
            };
        }

        public async Task<HttpResponseMessage> Ingreso(string email, string password)
        {
            var vendedor = new Usuario
            {
                Email = email,
                Password = password
            };
            var json = JsonConvert.SerializeObject(vendedor);

            HttpContent content = new StringContent(json);
            
            var url = string.Format("/Servicios/ClicHood/Acceso/ingreso");
            var response = await _client.PostAsync(url, content);

            return response;
        }

        public static Usuario ObtenerUsusario()
        {
            var vendedor = new Usuario
            {
                Nombre = "Alejandro",
                Apellidos = "Aguilar",
                Email = "kainraziellok@gmail.com"
            };

            return vendedor;
        }

        public async Task<HttpResponseMessage> RegistrarVendedor(Usuario vendedor)
        {
            var json = JsonConvert.SerializeObject(vendedor);
            HttpContent content = new StringContent(json);
            var url = string.Format("/Servicios/ClicHood/vendedores");
            var response = await _client.PostAsync(url, content);

            return response;
        }
    }
}
