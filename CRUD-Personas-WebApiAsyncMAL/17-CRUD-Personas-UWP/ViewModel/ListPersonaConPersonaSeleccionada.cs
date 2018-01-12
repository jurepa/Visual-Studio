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
        private ObservableCollection<Pokemon> _listado;
        private ObservableCollection<Pokemon> _listadoAux;
        private Pokemon _pokemonSeleccionado;
        private string _textoBusqueda;
        private DelegateCommand _delete;
        private DelegateCommand _addPersona;
        private DelegateCommand _savePersona;
        private DelegateCommand _actualizarLista;
        private ListadoPersonasBL _listadoBL;
        private string _textoReloj;
        private DispatcherTimer timer;
        private int _segundos;
        private bool _activo;
        //private DelegateCommand _searchPersona;
        #endregion
        #region "Constructores"
        public ListPersonaConPersonaSeleccionada()
        {
            activo = true;
            _listadoBL = new ListadoPersonasBL();
            cargarLista();
            timer = new DispatcherTimer();
            _segundos = 30;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        #endregion

        #region "Propiedades públicas"

        public bool activo
        {
            get { return _activo; }
            set {
                    _activo = value;
                    NotifyPropertyChanged("activo");
                }
        }
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
        public ObservableCollection<Pokemon> listadoAux
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

                    cargarLista();
                    _listadoAux = listado;
                    NotifyPropertyChanged("listado");
                    NotifyPropertyChanged("listadoAux");
                }
                else
                {
                    ExecuteSearchPersona();
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
        public ObservableCollection<Pokemon> listado
        {
            get { return _listado; }

            set
            {
                _listado = value;
            }
        }
        public Pokemon pokemonSeleccionado
        {
            get { return _pokemonSeleccionado; }
            set
            {
                _pokemonSeleccionado = value;
                _delete.RaiseCanExecuteChanged();
                _savePersona.RaiseCanExecuteChanged();

                //Notificación de cambio a la vista
                NotifyPropertyChanged("pokemonSeleccionado");
            }
        }
        #endregion
        public bool CanExecuteDelete()
        {
            bool canExecute = false;
            if (_pokemonSeleccionado != null)
            {
                if (!String.IsNullOrEmpty(_pokemonSeleccionado.nombrePokemon))
                {
                    canExecute = true;
                }

            }
            return canExecute;
        }

        private void ExecuteActualizarLista()
        {
            activo = true;
            cargarLista();
            NotifyPropertyChanged("listado");
            _segundos = 30;
        }
        public void ExecuteSearchPersona()
        {
            listadoAux = new ObservableCollection<Pokemon>();
            NotifyPropertyChanged("listadoAux");
            //string nombre = null;
            //for (int i = 0; i < _listado.Count; i++)
            //{
            //    nombre = _listado.ElementAt(i).nombre.ToLower();
            //    if (nombre.Contains(textoBusqueda.ToLower()))
            //    {
            //        listadoAux.Add(_listado.ElementAt(i));
            //        NotifyPropertyChanged("listadoAux");
            //    }
            //}
            IEnumerable<Pokemon> listadito = from persona in _listado where persona.nombrePokemon.ToLower().Contains(_textoBusqueda.ToLower()) select persona;

            listadoAux =new ObservableCollection<Pokemon>( listadito);
            NotifyPropertyChanged("listadoAux");
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
            pokemonSeleccionado = new Pokemon();
            NotifyPropertyChanged("pokemonSeleccionado");
        }
        //private bool canExecuteSavePersona()
        //{
        //    bool sePuede = false;
        //    if (_pokemonSeleccionado != null)
        //    {
        //        sePuede = true;

        //    }
        //    return sePuede;
        //}
        private void ExecuteSavePersona()
        {
            update();
        }

        private async void update()
        {
            if (_pokemonSeleccionado.idPokemon == 0)
            {
                _pokemonSeleccionado.idPokemon = listadoAux.ElementAt(listado.Count - 1).idPokemon + 1;

                await _listadoBL.insertPersona(_pokemonSeleccionado); 
                cargarLista();
                //NotifyPropertyChanged("personaSeleccionada");
                //NotifyPropertyChanged("listadoAux");
                //NotifyPropertyChanged("listado");
            }
            else
            {
                await _listadoBL.updatePersona(_pokemonSeleccionado);
                activo = true;
                cargarLista();
                NotifyPropertyChanged("pokemonSeleccionado");
                //NotifyPropertyChanged("listadoAux");
                //NotifyPropertyChanged("listado");
            }
        }
        private bool CanExecuteSavePersona()
        {
            bool sePuede = false;
            if (_pokemonSeleccionado != null)
            {
                sePuede = true;
            }
            return sePuede;
        }
        private void buscaPersona()
        {
            _listadoAux = new ObservableCollection<Pokemon>();
            NotifyPropertyChanged("listadoAux");
            string nombre = null;
            for (int i = 0; i < _listado.Count; i++)
            {
                nombre = _listado.ElementAt(i).nombrePokemon.ToLower();
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
            volverAJugar.Content = $"¿Está seguro de que de que desea eliminar el pokemon {_pokemonSeleccionado.nombrePokemon}?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";
            ContentDialogResult resultado = await volverAJugar.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {
                await _listadoBL.deletePersona(_pokemonSeleccionado.idPokemon);
                activo = true;
                cargarLista(); //No borra la persona seleccionada en el listado original, dnt know why
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
                activo = true;
                cargarLista();
                NotifyPropertyChanged("listado");
                if (!String.IsNullOrEmpty(_textoBusqueda))
                {
                    ExecuteSearchPersona();
                }
                _segundos = 30;
            }
        }
        private async void cargarLista()
        {
            this._listado = new ObservableCollection<Pokemon>(await _listadoBL.getListadoBL());
            NotifyPropertyChanged("listado");
            this._listadoAux = this._listado;
            NotifyPropertyChanged("listadoAux");
            activo = false;
        }
    }
}
