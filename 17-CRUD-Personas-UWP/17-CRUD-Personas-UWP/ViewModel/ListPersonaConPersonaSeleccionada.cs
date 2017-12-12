using _17_CRUD_Personas_UWP_BL;
using _17_CRUD_Personas_UWP_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _17_CRUD_Personas_UWP.ViewModel
{
    public class ListPersonaConPersonaSeleccionada : clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<Persona> _listado;
        private ObservableCollection<Persona> _listadoAux;
        private Persona _personaSeleccionada;
        private string _textoBusqueda;
        private DelegateCommand _delete;
        private DelegateCommand _addPersona;
        private DelegateCommand _savePersona;
        private DelegateCommand _actualizarLista;
        private ListadoPersonasBL _listadoBL;
        private string _textoReloj;
        private DispatcherTimer timer;
        private int _segundos;
        //private DelegateCommand _searchPersona;
        #endregion
        #region "Constructores"
        public ListPersonaConPersonaSeleccionada()
        {
            _listadoBL = new ListadoPersonasBL();
            this._listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
            this._listadoAux = this._listado;
            timer = new DispatcherTimer();
            _segundos = 30;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        #endregion

        #region "Propiedades públicas"
        public DelegateCommand delete
        {
            get
            {
                _delete = new DelegateCommand(ExecuteDelete, CanExecuteDelete);
                return _delete;
            }

            set
            {
                _delete = value;
            }
        }
        public DelegateCommand actualizarLista
        {
            get
            {
                _actualizarLista = new DelegateCommand(ExecuteActualizarLista);
                return _actualizarLista;
            }

            set
            {
                _actualizarLista = value;
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

                    _listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
                    _listadoAux = listado;
                    NotifyPropertyChanged("listado");
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
                _savePersona = new DelegateCommand(ExecuteSavePersona, CanExecuteSavePersona);
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
        public string textoReloj
        {
            get { return _textoReloj; }
            set
            {
                _textoReloj = value;
            }
        }
        public ObservableCollection<Persona> listado
        {
            get { return _listado; }

            set
            {
                _listado = value;
            }
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
                if (!String.IsNullOrEmpty(_personaSeleccionada.nombre))
                {
                    canExecute = true;
                }

            }
            return canExecute;
        }

        private void ExecuteActualizarLista()
        {
            listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
            listadoAux = this._listado;
            NotifyPropertyChanged("listado");
            NotifyPropertyChanged("listadoAux");
        }
        public void ExecuteSearchPersona()
        {
            listadoAux = new ObservableCollection<Persona>();
            NotifyPropertyChanged("listadoAux");
            string nombre = null;
            for (int i = 0; i < _listado.Count; i++)
            {
                nombre = _listado.ElementAt(i).nombre.ToLower();
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
            mostrarSeguroDelete();
        }
        public void ExecuteAddPersona()
        {
            personaSeleccionada = new Persona();
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
                _personaSeleccionada.idPersona = listadoAux.ElementAt(listado.Count - 1).idPersona + 1;
                _listadoBL.insertPersona(_personaSeleccionada);
                _listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
                _listadoAux = listado;
                //NotifyPropertyChanged("personaSeleccionada");
                //NotifyPropertyChanged("listadoAux");
                //NotifyPropertyChanged("listado");
            }
            else
            {
                _listadoBL.updatePersona(_personaSeleccionada);
                _listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
                _listadoAux = listado;
                NotifyPropertyChanged("personaSeleccionada");
                //NotifyPropertyChanged("listadoAux");
                //NotifyPropertyChanged("listado");
            }
        }
        private bool CanExecuteSavePersona()
        {
            bool sePuede = false;
            if (_personaSeleccionada != null)
            {
                sePuede = true;
            }
            return sePuede;
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
        public async void mostrarSeguroDelete()
        {

            ContentDialog volverAJugar = new ContentDialog();
            volverAJugar.Title = "Eliminar";
            volverAJugar.Content = $"¿Está seguro de que de que desea eliminar el usuario {_personaSeleccionada.nombre} {_personaSeleccionada.apellidos}?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";
            ContentDialogResult resultado = await volverAJugar.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {
                _listadoBL.deletePersona(_personaSeleccionada.idPersona);
                _listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
                _listadoAux = listado; //No borra la persona seleccionada en el listado original, dnt know why
                //NotifyPropertyChanged("listado");
                //NotifyPropertyChanged("listadoAux");
            }

        }
        private void timer_Tick(object sender, object e)
        {
            _segundos--;
            if (_segundos >= 10)
            {
                _textoReloj = $"0:{_segundos.ToString()}";
                NotifyPropertyChanged("textoReloj");
            }
            else
            {
                _textoReloj = $"0:0{_segundos.ToString()}";
                NotifyPropertyChanged("textoReloj");
            }
            if (_segundos == 0)
            {
                _listadoBL = new ListadoPersonasBL();
                this._listado = new ObservableCollection<Persona>(_listadoBL.getListadoBL());
                this._listadoAux = this._listado;
                NotifyPropertyChanged("listado");
                NotifyPropertyChanged("listadoAux");
                _segundos = 30;
            }
        }
    }
}
