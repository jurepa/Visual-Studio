using PasarDatosAlControlador.Models.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasarDatosAlControlador.Models.ViewModels
{
    public class PersonaListDepartamento:Persona
    {
        public ListDepartamento lista { get; set; }

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
        //[Display(Name = "Departamentos")]
        //public int SelectedDepartamentoId { get; set; }

        /*public IEnumerable<SelectListItem> ItemsLista
        {
            get { return new SelectList(lista.lista, "idDepartamento", "nombre"); }
        }*/
    }
}