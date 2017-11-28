using ExamenPrimeraEvEj1___ET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGExamenPrimeraEvEj1.ViewModel
{
    public class AlumnoConBecaInt
    {
        /// <summary>
        /// ViewModel que contiene un objeto alumno y un entero Beca. 
        /// Como recibimos del formulario la beca como entero, lo que hago es asignarle a alumno.beca un Convert.ToDecimal(becaInt)
        /// </summary>
        public Alumno alumno { get; set; }
        [Required (ErrorMessage ="Campo Requerido")]
        public int becaINT { get; set; }

        public AlumnoConBecaInt()
        {
            becaINT = 0;
            alumno = new Alumno();
        }
    }
}