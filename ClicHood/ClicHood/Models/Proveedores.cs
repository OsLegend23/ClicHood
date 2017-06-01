using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicHood.Models
{
    public class Proveedores
    {
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string FotoProveedor { get; set; }
        public bool EsFavorito { get; set; }
        public bool EsPrincipal { get; set; }
    }
}
