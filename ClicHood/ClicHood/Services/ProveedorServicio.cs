using ClicHood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicHood.Services
{
    public class ProveedorServicio
    {
        public List<Proveedores> ConsultaProveedores()
        {
            var lista = new List<Proveedores>();
            lista.Add(new Proveedores() {
                NombreProveedor = "Proveedor 1",
                FotoProveedor = "https://design.atlassian.com/images/personas/alana.jpg"
            });
            lista.Add(new Proveedores()
            {
                NombreProveedor = "Proveedor 2",
                FotoProveedor = "https://design.atlassian.com/images/personas/alana.jpg"
            });

            return lista;
        }
    }
}
