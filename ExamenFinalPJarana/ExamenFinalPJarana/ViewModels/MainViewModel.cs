using Capa_BL.Gestoras;
using Capa_BL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * README!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 * 
 * -Funciona todo aunque me hubiera gustado mejorar dos cosas:
 *     
 *     -Me falta controlar que las puntuaciones sean solo, 5, 10, que estén vacías y que haya dos jugadores seleccionados antes
 *     de darle al botón de aceptar, el cual con un command realiza el insert. Lo iba a hacer (línea 345), 
 *     pero me he dado cuenta de que tenía que controlar un montón de cosas y me he centrado en realizar el insert
 *     de los resultados del combate.
 *     
 *      -El id de la categoría de premios se lo asigno a pelo desde la lista de categoriasPremios
 *     en el constructor porque no me daba tiempo, lo suyo hubiera sido buscar el id de la categoria.
 *     
 *     -
 */
namespace ExamenFinalPJarana.ViewModels
{
    public class MainViewModel:clsVMBase
    {
#region privados
        private List<Combate> _listadoCombates;
        private Combate _combateSeleccionado;
        private List<Luchador> _listadoLuchadores1;
        private Luchador _luchadorSeleccionado1;
        private List<Luchador> _listadoLuchadores2;
        private Luchador _luchadorSeleccionado2;
        private List<Casa> _listadoCasas;
        private List<CategoriasPremios> _listadoCategoriasPremios;
        private ClasificacionCombate _resultadoSangriento2;
        private ClasificacionCombate _resultadoVictorioso2;
        private ClasificacionCombate _resultadoEspectacular2;
        private ClasificacionCombate _resultadoSangriento1;
        private ClasificacionCombate _resultadoVictorioso1;
        private ClasificacionCombate _resultadoEspectacular1;
        private DelegateCommand _insertarResultadoLuchador2;
        private DelegateCommand _insertarResultadoLuchador1;

        #endregion
        #region publicos
        public DelegateCommand insertarResultadoLuchador1
        {
            get
            {
                _insertarResultadoLuchador1 = new DelegateCommand(insertResultadoLuchador1);
                return _insertarResultadoLuchador1;
            }
            set
            {
                _insertarResultadoLuchador1 = value;
                NotifyPropertyChanged("insertarResultadoLuchador1");
            }
        }
        public DelegateCommand insertarResultadoLuchador2
        {
            get
            {
                _insertarResultadoLuchador2 = new DelegateCommand(insertResultadoLuchador2/*,CanExecuteInsert*/);
                return _insertarResultadoLuchador2;
            }
            set
            {
                _insertarResultadoLuchador2 = value;
                NotifyPropertyChanged("insertarResultadoLuchador2");
            }
        }
        public ClasificacionCombate resultadoSangriento2
        {
            get
            {
                return _resultadoSangriento2;
            }
            set
            {
                _resultadoSangriento2 = value;
                NotifyPropertyChanged("resultadoSangriento2");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public ClasificacionCombate resultadoEspectacular2
        {
            get
            {
                return _resultadoEspectacular2;
            }
            set
            {
                _resultadoEspectacular2 = value;
                
                NotifyPropertyChanged("resultadoEspectacular2");
               // _insertarResultadoLuchador2.RaiseCanExecuteChanged();
            }

        }
        public ClasificacionCombate resultadoEspectacular1
        {
            get
            {
                return _resultadoEspectacular1;
            }
            set
            {
                _resultadoEspectacular1 = value;
                NotifyPropertyChanged("resultadoEspectacular1");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public ClasificacionCombate resultadoSangriento1
        {
            get
            {
                return _resultadoSangriento1;
            }
            set
            {
                _resultadoSangriento1 = value;
                NotifyPropertyChanged("resultadoSangriento1");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public ClasificacionCombate resultadoVictorioso1
        {
            get
            {
                return _resultadoVictorioso1;
            }
            set
            {
                _resultadoVictorioso1 = value;
                NotifyPropertyChanged("resultadoVictorioso1");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public ClasificacionCombate resultadoVictorioso2
        {
            get
            {
                return _resultadoVictorioso2;
            }
            set
            {
                _resultadoVictorioso2 = value;
                NotifyPropertyChanged("resultadoVictorioso2");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public List<Combate> listadoCombates
        {
            get
            {
                return _listadoCombates;
            }
            set
            {
                _listadoCombates = value;
                NotifyPropertyChanged("listadoCombates");
            }
        }
        public Combate combateSeleccionado
        {
            get
            {
                return _combateSeleccionado;
            }
            set
            {
                _combateSeleccionado = value;
                NotifyPropertyChanged("combateSeleccionado");
                _listadoLuchadores1 = new ListadoLuchadoresBL().getListadoLuchadoresBL();
                _luchadorSeleccionado1 = null;
                _luchadorSeleccionado2 = null;
                _listadoLuchadores2 = null;
                NotifyPropertyChanged("luchadorSeleccionado2");
                NotifyPropertyChanged("luchadorSeleccionado1");
                NotifyPropertyChanged("listadoLuchadores2");
                NotifyPropertyChanged("listadoLuchadores1");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();
                
            }
        }
        public List<Luchador> listadoLuchadores1
        {
            get
            {
                return _listadoLuchadores1;
            }
            set
            {
                _listadoLuchadores1 = value;
                NotifyPropertyChanged("listadoLuchadores1");
            }
        }

        public Luchador luchadorSeleccionado1
        {
            get
            {
                return _luchadorSeleccionado1;
            }
            set
            {
                _luchadorSeleccionado1 = value;
                if (_luchadorSeleccionado1 != null)
                {
                    _resultadoEspectacular1.idLuchador = _luchadorSeleccionado1.idLuchador;
                    _resultadoVictorioso1.idLuchador = _luchadorSeleccionado1.idLuchador;
                    _resultadoSangriento1.idLuchador = _luchadorSeleccionado1.idLuchador;
                    asignarCasa(_luchadorSeleccionado1);
                    asignarFotos(_luchadorSeleccionado1);
                    NotifyPropertyChanged("luchadorSeleccionado1");
                    this._listadoLuchadores2 = new ListadoLuchadoresBL().getListadoLuchadoresBL();
                    _listadoLuchadores2.RemoveAt(_luchadorSeleccionado1.idLuchador - 1);
                    NotifyPropertyChanged("listadoLuchadores2");
                }
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }
        }
        public List<Luchador> listadoLuchadores2
        {
            get
            {
                return _listadoLuchadores2;
            }
            set
            {
                _listadoLuchadores2 = value;
                NotifyPropertyChanged("listadoLuchadores2");
            }
        }

        public Luchador luchadorSeleccionado2
        {
            get
            {
                return _luchadorSeleccionado2;
            }
            set
            {
                _luchadorSeleccionado2 = value;
                if (_luchadorSeleccionado2 != null)
                {
                    asignarCasa(_luchadorSeleccionado2);
                    asignarFotos(_luchadorSeleccionado2);
                    _resultadoEspectacular2.idLuchador = _luchadorSeleccionado2.idLuchador;
                    _resultadoVictorioso2.idLuchador = _luchadorSeleccionado2.idLuchador;
                    _resultadoSangriento2.idLuchador = _luchadorSeleccionado2.idLuchador;
                    
                }
                NotifyPropertyChanged("luchadorSeleccionado2");
                //_insertarResultadoLuchador2.RaiseCanExecuteChanged();

            }

        }

        #endregion
        public MainViewModel()
        {
            this._listadoCombates = new ListadoCombatesBL().getListadoCombatesBL();
            NotifyPropertyChanged("listadoCombates");
            this._listadoCasas = new ListadoCasasBL().getListadoCasasBL();
            this._listadoCategoriasPremios = new ListadoCategoriasPremiosBL().getListadoCategoriasPremiosBL();
            _resultadoEspectacular1 = new ClasificacionCombate();
            _resultadoEspectacular1.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(1).idCategoriaPremio;
            _resultadoEspectacular2 = new ClasificacionCombate();
            _resultadoEspectacular2.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(1).idCategoriaPremio;
            _resultadoSangriento1 = new ClasificacionCombate();
            _resultadoSangriento1.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(0).idCategoriaPremio;
            _resultadoSangriento2 = new ClasificacionCombate();
            _resultadoSangriento2.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(0).idCategoriaPremio;
            _resultadoVictorioso1 = new ClasificacionCombate();
            _resultadoVictorioso1.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(2).idCategoriaPremio;
            _resultadoVictorioso2 = new ClasificacionCombate();
            _resultadoVictorioso2.idCategoriaPremio = _listadoCategoriasPremios.ElementAt(2).idCategoriaPremio;
           
        }
        /// <summary>
        /// Asigna el nombre de la casa al luchador que se le pase por parametros
        /// </summary>
        /// <param name="luchador"></param>
        public void asignarCasa(Luchador luchador)
        {
            bool encontrado = false;
            if (luchador != null)
            {
                for (int i = 0; i < _listadoCasas.Count && !encontrado; i++)
                {
                    if (_listadoCasas.ElementAt(i).idCasa == luchador.idCasa)
                    {
                        luchador.nombreCasa = _listadoCasas.ElementAt(i).nombreCasa;
                        encontrado = true;
                    }
                }
            }
        }
        /// <summary>
        /// Asigna la foto de la casa y de perfil segun el jugador pasado
        /// </summary>
        /// <param name="luchador"></param>
        public void asignarFotos(Luchador luchador)
        {
            if (luchador != null)
            {
                luchador.fotoCasa = new Uri("ms-appx:///Assets/Images/Casas/" + luchador.idCasa + ".png");
                luchador.fotoPerfil = new Uri("ms-appx:///Assets/Images/Luchadores/" + luchador.idLuchador + ".jpg");
            }
        }
        /// <summary>
        /// Inserta las puntuaciones del jugador 2 y restablece los textboxes
        /// </summary>
        public void insertResultadoLuchador2()
        {
            GestoraClasificacionCombatesBL gestora = new GestoraClasificacionCombatesBL();
            _resultadoEspectacular2.idCombate = _combateSeleccionado.idCombate;
            _resultadoSangriento2.idCombate = _combateSeleccionado.idCombate;
            _resultadoVictorioso2.idCombate = _combateSeleccionado.idCombate;
            gestora.insertClasificacionCombate(_resultadoVictorioso2);
            gestora.insertClasificacionCombate(_resultadoEspectacular2);
            gestora.insertClasificacionCombate(_resultadoSangriento2);
            _resultadoEspectacular2.puntos = 0;
            _resultadoSangriento2.puntos = 0;
            _resultadoVictorioso2.puntos = 0;
            NotifyPropertyChanged("resultadoEspectacular2");
            NotifyPropertyChanged("resultadoSangriento2");
            NotifyPropertyChanged("resultadoVictorioso2");
        }

        /// <summary>
        /// Este método que no me ha dado tiempo a implementar deshabilitaría el botón de aceptar en caso de que no hubieran dos jugadores en el combate,
        /// en caso de que no hubiera puntos en alguno de los textboxes, o en caso de que la puntuación en los textboxes no fueran ni 5 ni 10.
        /// Como estar está, pero no completo.
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteInsert()
        {
            bool sePuede = true;
            if (_luchadorSeleccionado1 == null || luchadorSeleccionado2 == null || _resultadoEspectacular1.puntos == 0
                || _resultadoEspectacular2.puntos == 0 || _resultadoSangriento1.puntos == 0 || _resultadoSangriento2.puntos == 0
                || _resultadoVictorioso1.puntos == 0 || _resultadoVictorioso2.puntos == 0)
            {
                sePuede = false;
            }
            return sePuede;
        }
        /// <summary>
        /// Inserta las puntuaciones del jugador 2 y restablece los textboxes
        /// </summary>
        public void insertResultadoLuchador1()
        {
            GestoraClasificacionCombatesBL gestora = new GestoraClasificacionCombatesBL();
            _resultadoEspectacular1.idCombate = _combateSeleccionado.idCombate;
            _resultadoSangriento1.idCombate = _combateSeleccionado.idCombate;
            _resultadoVictorioso1.idCombate = _combateSeleccionado.idCombate;
            gestora.insertClasificacionCombate(_resultadoVictorioso1);
            gestora.insertClasificacionCombate(_resultadoEspectacular1);
            gestora.insertClasificacionCombate(_resultadoSangriento1);
            _resultadoEspectacular1.puntos = 0;
            _resultadoSangriento1.puntos = 0;
            _resultadoVictorioso1.puntos = 0;
            NotifyPropertyChanged("resultadoEspectacular1");
            NotifyPropertyChanged("resultadoSangriento1");
            NotifyPropertyChanged("resultadoVictorioso1");
        }
    }
}
