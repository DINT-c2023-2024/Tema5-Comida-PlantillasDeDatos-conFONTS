using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> tiposComida;

        public ObservableCollection<string> TiposComida
        {
            get { return tiposComida; }
            set
            {
                tiposComida = value;
                NotifyPropertyChanged("TiposComida");
            }
        }

        private ObservableCollection<Plato> listaPlatos;

        public ObservableCollection<Plato> ListaPlatos
        {
            get { return listaPlatos; }
            set { 
                    listaPlatos = value;
                    NotifyPropertyChanged("ListaPlatos");
                }
        }

        private Plato platoSeleccionado;

        public Plato PlatoSeleccionado
        {
            get { return platoSeleccionado; }
            set { 
                    platoSeleccionado = value;
                    NotifyPropertyChanged("PlatoSeleccionado");
                }
        }

        public MainWindowVM()
        {
            // En el proyecto localizamos las fotos de los platos de comida en la carpeta "FotosPlatos",
            // la cual está al mismo nivel que el proyecto ".\FotosPlatos". También incorporamos la carpeta y
            // sus fotos al proyecto.
            ListaPlatos = Plato.GetSamples(@".\FotosPlatos");
            TiposComida = new ObservableCollection<string> { "China", "Americana", "Mexicana" };
        }

        public void QuitarSeleccionado()
        {
            PlatoSeleccionado = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
