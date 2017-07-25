using ClicHood.Models;
using ClicHood.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClicHood.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        private Usuario _vendedor;

        public Usuario Vendedor
        {
            get { return _vendedor; }
            set {
                _vendedor = value;
                OnPropertyChanged();
            }
        }

        public UsuarioViewModel()
        {
            UsuarioServicio servicio = new UsuarioServicio();

            Vendedor = UsuarioServicio.ObtenerUsusario();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
