using PasarDatosAlControlador.Models.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasarDatosAlControlador.Models.ViewModels
{
    /// <summary>
    /// VM que contiene los datos de una persona y un listado departamento
    /// </summary>
    public class PersonaListDepartamento
    {
        [HiddenInput(DisplayValue =false)]
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
        public ListDepartamento lista { get; set; }
        /// <summary>
        /// Constructor Vacío, le damos valores a los atributos y creamos el list.
        /// </summary>
        public PersonaListDepartamento()
        {
            idPersona = 1;
            nombre = "Pablo";
            apellidos = "Jarana García";
            direccion = "Aquí o allí";
            fechaNac = new DateTime(1998,03,19);
            idDepartamento = 3;
            telefono = "No tengo";
            lista = new ListDepartamento();
        }
        /// <summary>
        /// Método que devuelve el nombre del departamento dependiendo del id.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string getNombreDepartamentoPorId(int d)
        {
            string nombreDep = null;
            foreach (var departamento in lista.lista)
            {
                if (departamento.idDepartamento==this.idDepartamento)
                {
                    nombreDep = departamento.nombre;
                }

            }
            return nombreDep;
        }
        //[Display(Name = "Departamentos")]
        //public int SelectedDepartamentoId { get; set; }

        /*public IEnumerable<SelectListItem> ItemsLista
        {
            get { return new SelectList(lista.lista, "idDepartamento", "nombre"); }
        }*/
    }
}