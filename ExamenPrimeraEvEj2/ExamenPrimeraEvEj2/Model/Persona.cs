using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ExamenPrimeraEvEj2.Model
{
    /// <summary>
    /// Clase Persona, con idDepartamento
    /// </summary>
    public class Persona:INotifyPropertyChanged
    {
        #region privados
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        #endregion
        #region publicas
        public int idPersona { get; set; }
        public string nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("nombre");
            }
        }
        public string apellidos { get { return _apellidos; } set { _apellidos = value; NotifyPropertyChanged("apellidos"); } }

        public DateTime fechaNac { get; set; }
        
        public string direccion { get { return _direccion; } set { _direccion = value; NotifyPropertyChanged("direccion"); } }

        public string telefono { get { return _telefono; } set { _telefono = value; NotifyPropertyChanged("telefono"); } }
        public int idDepartamento { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}