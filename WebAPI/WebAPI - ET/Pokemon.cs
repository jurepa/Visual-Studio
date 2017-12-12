using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI___ET
{
    public class Pokemon
    {
        public int idPokemon { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        public string nombrePokemon { get; set; }
        [Required(ErrorMessage ="Campo Requerido"), Range(minimum:0,maximum:3)]
        public Byte numEvoluciones { get; set; }
        [Required(ErrorMessage ="El pokemon debe tener una generación"), Range(minimum:1,maximum:7,ErrorMessage ="Elige una generación de la 1 a la 7")]
        public Byte generacion { get; set; }
        [Required(ErrorMessage ="El pokemon debe tener al menos una habilidad")]
        public string habilidad1 { get; set; }
        public string habilidad2 { get; set; }
        public string habilidadOculta { get; set; }
        [Required(ErrorMessage ="El pokemon debe tener una altura"),Range(minimum:0.1,maximum:100.0,ErrorMessage ="La altura debe ser mayor a 0,1 metros y menor a 100 metros")]
        public double altura { get; set; }
        [Required(ErrorMessage = "El pokemon debe tener un peso"), Range(minimum: 0.1, maximum: 500.0, ErrorMessage = "El peso debe ser mayor a 0,1 kg y menor a 500 kg")]
        public double peso { get; set; }
        [Required(ErrorMessage ="El pokemon vive en algún lao cohone"), MaxLength(50,ErrorMessage ="El hábitat debe ser menor o igual a 50 caracteres")]
        public string habitat { get; set; }

    }
}
