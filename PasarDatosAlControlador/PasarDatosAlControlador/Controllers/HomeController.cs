using PasarDatosAlControlador.Models;
using PasarDatosAlControlador.Models.Lists;
using PasarDatosAlControlador.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PasarDatosAlControlador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// Se ejecutará al ejecutar la aplicación, devolvemos a la vista la clase PersonaListDepartamento,
        /// la cual hereda de persona(contiene datos de una persona) y un List<Departamento>
        /// </summary>
        /// <returns></returns>
        public ActionResult Editar()
        {
            PersonaListDepartamento pld = new PersonaListDepartamento();
            return View(pld);
        }
        /// <summary>
        /// Se ejecutará al darle al botón enviar, recibiremos los datos de la persona, modificados o no.
        /// Lo adaptamos a la clase PersonaConNombreDepartamento(hereda de persona y ya no tiene List<Departamento>) 
        /// y devolvemos la view PersonaModificada con el objeto de la clase PersonaConNombreDepartamento  
        /// </summary>
        /// <param name="pld"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PersonaModificada(PersonaListDepartamento pld)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", pld);
            }
            else
            {
                PersonaConNombreDepartamento persona = new PersonaConNombreDepartamento();
                persona.idDepartamento = pld.idDepartamento;
                persona.idPersona = pld.idPersona;
                persona.nombre = pld.nombre;
                persona.apellidos = pld.apellidos;
                persona.direccion = pld.direccion;
                persona.telefono = pld.telefono;
                persona.fechaNac = pld.fechaNac;
                persona.nombreDepartamento = pld.getNombreDepartamentoPorId(pld.idDepartamento);
                return View(persona); //Crear un viewModel que herede de persona y que tenga como propiedad añadida el nombre del departamento
            }            
        }
    }
}