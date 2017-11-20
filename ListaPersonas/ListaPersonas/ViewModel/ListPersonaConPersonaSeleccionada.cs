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
        private DelegateCommand _addPersona;
        private DelegateCommand _savePersona;
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
        public DelegateCommand addPersona
        {
            get
            {
                _addPersona = new DelegateCommand(ExecuteAddPersona);
                return _addPersona;
            }
            set
            {
                _addPersona = value;
            }
        }
        public DelegateCommand savePersona
        {
            get
            {
                _savePersona = new DelegateCommand(ExecuteSavePersona);
                return _savePersona;
            }
            set
            {
                _savePersona = value;
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
                _savePersona.RaiseCanExecuteChanged();
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
        public void ExecuteAddPersona()
        {
            _personaSeleccionada = new Persona();
            NotifyPropertyChanged("personaSeleccionada");
        }
        //private bool canExecuteSavePersona()
        //{
        //    bool sePuede = false;
        //    if (_personaSeleccionada != null)
        //    {
        //        sePuede = true;

        //    }
        //    return sePuede;
        //}
        private void ExecuteSavePersona()
        {
            if (_personaSeleccionada.idPersona == 0)
            {
                _personaSeleccionada.idPersona=listado.ElementAt(listado.Count - 1).idPersona+1;
                NotifyPropertyChanged("personaSeleccionada");
                listado.Add(_personaSeleccionada);
                NotifyPropertyChanged("listado");
            }
        }

    }
}
