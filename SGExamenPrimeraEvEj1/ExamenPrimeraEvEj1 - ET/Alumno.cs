using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvEj1___ET
{
    public class Alumno
    {
        public int idAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public string apellidoAlumno { get; set; }
        [Required(ErrorMessage="Campo Requerido")]
        public Decimal beca { get; set; }
        public int idCurso { get; set; }
    }
}
