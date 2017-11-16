using ListaPersonas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ListaPersonas.ViewModel
{
    public class ListPersonaConPersonaSeleccionada :INotifyPropertyChanged
    {
        #region "Atributos"
        private ObservableCollection<Persona> _listado;
        private int _indicePersonaSeleccionada;
        private Persona _personaSeleccionada;
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        #region "Constructores"
        public ListPersonaConPersonaSeleccionada()
        {
            ListPersona lista = new ListPersona();
            this._listado = lista.listado;
        }
        #endregion
        
        #region "Propiedades públicas"
        public ObservableCollection<Persona> listado
        {
            get { return _listado; }
        }
        public int indicePersonaSeleccionada
        {
            get {
                return _indicePersonaSeleccionada; }
            set
            {
                _indicePersonaSeleccionada = value;
                //NotifyPropertyChanged("indicePersonaSeleccionada");
            }
        }
        public Persona personaSeleccionada
        {
            get { return _personaSeleccionada; }
            set
            {
                _personaSeleccionada = value;
                //Notificación de cambio a la vista
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        #endregion
        /// <summary>
        /// Método para lanzar el evento
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            _listado.RemoveAt(_indicePersonaSeleccionada);
            NotifyPropertyChanged("listado");
        }


    }
}
