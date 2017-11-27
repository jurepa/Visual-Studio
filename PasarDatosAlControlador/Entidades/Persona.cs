using System;
using System.Collections.Generic;
using System.Linq;


namespace PasarDatosAlControlador.Models
{
    /// <summary>
    /// Clase Persona, con idDepartamento
    /// </summary>
    public class Persona
    {

        public int idPersona { get; set; }

        public string nombre { get; set; }
        public string apellidos { get; set; }

        public DateTime fechaNac { get; set; }
        
        public string direccion { get; set; }

        public string telefono { get; set; }
        public int idDepartamento { get; set; }
    }

}