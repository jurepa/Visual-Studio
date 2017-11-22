using System;
using System.Collections.Generic;
using System.Linq;


namespace _04_GridFormulario.Models
{
    public class Persona
    {
        public Persona()
        {
            this.idPersona = 1;
            this.nombre = "Pablo";
            this.apellidos = "Jarana";
            this.direccion = "En mi casa";
            this.telefono = "Ejo k é";
            this.fechaNac = null;
        }
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime? fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }

}