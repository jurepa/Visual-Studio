using ExamenPrimeraEvEj2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvEj2.ViewModel
{
    /// <summary>
    /// El viewmodel contendra un listado de personas de cada curso, los cuales no mostraremos.
    /// Mostraremos el ListadoAux, el cual lo iniciaremos a un curso u otro dependiendo del curso que haya seleccionado el usuario, es decir,
    /// dependiendo de cursoSeleccionado.
    /// 
    /// </summary>
    class MainPageVM:clsVMBase
    {
        private ObservableCollection<Persona> _curso1;
        private ObservableCollection<Persona> _curso2;
        private ObservableCollection<Persona> _listadoAux;
        private ObservableCollection<String> _cursos;
        private string _cursoSeleccionado;

        public MainPageVM()
        {
            ListPersona listados = new ListPersona();
            _cursos = new ObservableCollection<string>();
            _cursos.Add("Primer curso");
            _cursos.Add("Segundo curso");
            this._curso1 = listados.curso1;
            this._curso2 = listados.curso2;
        }
        public string cursoSeleccionado
        {
            get
            {
                return _cursoSeleccionado;
            }
            set
            {
                _cursoSeleccionado = value;
                NotifyPropertyChanged("cursoSeleccionado");
                if (_cursoSeleccionado.Equals("Primer curso"))
                {
                    _listadoAux = curso1;
                    NotifyPropertyChanged("listadoAux");
                }
                else if (_cursoSeleccionado.Equals("Segundo curso"))
                {
                    _listadoAux = curso2;
                    NotifyPropertyChanged("listadoAux");
                }
                else
                {
                    _listadoAux = new ObservableCollection<Persona>();
                    NotifyPropertyChanged("listadoAux");
                }
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
                
            }
        }
        public ObservableCollection<String> cursos
        {
            get
            {
                return _cursos;
            }
            set
            {
                _cursos = value;
            }
        }
        public ObservableCollection<Persona> curso1
        {
            get
            {
                return _curso1;
            }
            set
            {
                _curso1 = value;
                NotifyPropertyChanged("curso1");
            }
        }
        public ObservableCollection<Persona> curso2
        {
            get
            {
                return _curso2;
            }
            set
            {
                _curso2 = value;
                NotifyPropertyChanged("curso2");
            }
        }
    }
}
