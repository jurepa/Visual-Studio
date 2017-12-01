using _17_CRUD_Personas_UWP_BL;
using _17_CRUD_Personas_UWP_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CRUD_Personas_UWP.ViewModel
{
    public class ListPersonaConPersonaSeleccionada :clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<Persona> _listado;
        private ObservableCollection<Persona> _listadoAux;
        private Persona _personaSeleccionada;
        private string _textoBusqueda;
        private DelegateCommand _delete;
        private DelegateCommand _addPersona;
        private DelegateCommand _savePersona;
        //private DelegateCommand _searchPersona;
        #endregion
        #region "Constructores"
        public ListPersonaConPersonaSeleccionada()
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            this._listado = new ObservableCollection<Persona>(listado.getListadoBL());
            this._listadoAux = this._listado;
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
        public ObservableCollection<Persona> listadoAux
        {
            get
            {
                return _listadoAux;
            }

            set
            {
                _listadoAux = value;
                NotifyPropertyChanged("listadoAux");
            }
        }
        public string textoBusqueda
        {
            get
            {
                return _textoBusqueda;
            }

            set
            {
                _textoBusqueda = value;
                //_searchPersona.RaiseCanExecuteChanged();
                if (String.IsNullOrWhiteSpace(_textoBusqueda))
                {
                    _listadoAux = _listado;
                    NotifyPropertyChanged("listadoAux");
                }
                else
                {
                    buscaPersona();
                }
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
       /* public DelegateCommand searchPersona
        {
            get
            {
                _searchPersona = new DelegateCommand(ExecuteSearchPersona,CanExecuteSearchPersona);
                return _searchPersona;
                
            }

            set
            {
                _searchPersona = value;
            }
        }*/
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

        public void ExecuteSearchPersona()
        {
            listadoAux = new ObservableCollection<Persona>();
            NotifyPropertyChanged("listadoAux");
            string nombre=null;
            for (int i = 0; i < _listado.Count; i++)
            {
                nombre =_listado.ElementAt(i).nombre.ToLower();
                if (nombre.Contains(textoBusqueda.ToLower()))
                {
                    listadoAux.Add(_listado.ElementAt(i));
                    NotifyPropertyChanged("listadoAux");
                }
            }
        }
        public bool CanExecuteSearchPersona()
        {
            bool encontrado = false;
            if (!String.IsNullOrEmpty(textoBusqueda))
            {
                encontrado = true;
            }
            else
            {
                listadoAux = listado;
                NotifyPropertyChanged("listadoAux");
            }
            return encontrado;
        }
        public void ExecuteDelete()
        {
            listadoAux.Remove(_personaSeleccionada);
            listado.Remove(_personaSeleccionada); //No borra la persona seleccionada en el listado original, dnt know why
            NotifyPropertyChanged("listado");
            NotifyPropertyChanged("listadoAux");
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
                _personaSeleccionada.idPersona=listadoAux.ElementAt(listado.Count - 1).idPersona+1;
                NotifyPropertyChanged("personaSeleccionada");
                listadoAux.Add(_personaSeleccionada);
                NotifyPropertyChanged("listadoAux");
            }
        }

        private void buscaPersona()
        {
            _listadoAux = new ObservableCollection<Persona>();
            NotifyPropertyChanged("listadoAux");
            string nombre = null;
            for (int i = 0; i < _listado.Count; i++)
            {
                nombre = _listado.ElementAt(i).nombre.ToLower();
                if (nombre.Contains(_textoBusqueda.ToLower()))
                {
                    _listadoAux.Add(_listado.ElementAt(i));
                    NotifyPropertyChanged("listadoAux");
                }
            }

        }
    }
}
