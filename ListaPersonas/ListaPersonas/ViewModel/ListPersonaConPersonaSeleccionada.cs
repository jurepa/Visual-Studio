using _13_DataContext.ViewModels;
using ListaPersonas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaPersonas.ViewModel
{
    public class ListPersonaConPersonaSeleccionada :clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<Persona> _listado;
        private Persona _personaSeleccionada;
        private DelegateCommand _delete;
        #endregion
        #region "Constructores"
        public ListPersonaConPersonaSeleccionada()
        {
            ListPersona lista = new ListPersona();
            this._listado = lista.listado;
        }
        #endregion
        
        #region "Propiedades públicas"
        public DelegateCommand delete
        {
            get
            {
                _delete= new DelegateCommand(ExecuteDelete, CanExecuteDelete);
                return _delete;
            }

            set
            {
                _delete = value;
            }
        }
        public ObservableCollection<Persona> listado
        {
            get { return _listado; }
        }
        public Persona personaSeleccionada
        {
            get { return _personaSeleccionada; }
            set
            {
                _personaSeleccionada = value;
                _delete.RaiseCanExecuteChanged();
                //Notificación de cambio a la vista
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        #endregion
        public bool CanExecuteDelete()
        {
            bool canExecute = false;
            if (_personaSeleccionada != null)
            {
                canExecute = true;
            }
            return canExecute;
        }

        public void ExecuteDelete()
        {
            listado.Remove(_personaSeleccionada);
            NotifyPropertyChanged("listado");
        }




    }
}
