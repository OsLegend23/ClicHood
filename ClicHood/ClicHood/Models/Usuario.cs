using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicHood.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public string FBToken { get; set; }
        
    }

    public class Respuesta
    {
        public int codeResponse { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public Usuario data { get; set; }
    }
}
