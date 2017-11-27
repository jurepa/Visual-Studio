using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CRUD_Personas_Entidades
{
    /// <summary>
    /// Clase Persona, con idDepartamento
    /// </summary>
    public class Persona
    {
        public int idPersona { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }
        [MaxLength(200, ErrorMessage = "Longitud Máxima 200 caracteres")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio"), MaxLength(50, ErrorMessage = "La longitud máxima del apellido es de 50 caracteres")]
        public string apellidos { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNac { get; set; }
        public int idDepartamento { get; set; }
        [RegularExpression("^9[0-9]{8}$", ErrorMessage = "Formato de teléfono incorrecto")]
        public string telefono { get; set; }
    }

}