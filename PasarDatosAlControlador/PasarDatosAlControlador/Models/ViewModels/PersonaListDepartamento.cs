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
    public class PersonaListDepartamento:Persona
    {

        public ListDepartamento lista { get; set; }
        /// <summary>
        /// Constructor Vacío, le damos valores a los atributos y creamos el list.
        /// </summary>
        public PersonaListDepartamento()
        {
            base.idPersona = 1;
            base.nombre = "Pablo";
            base.apellidos = "Jarana García";
            base.direccion = "Aquí o allí";
            base.fechaNac = new DateTime(1998,03,19);
            base.idDepartamento = 3;
            base.telefono = "No tengo";
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