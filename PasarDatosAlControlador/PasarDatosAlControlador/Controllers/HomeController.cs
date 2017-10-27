using PasarDatosAlControlador.Models;
using PasarDatosAlControlador.Models.Lists;
using PasarDatosAlControlador.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasarDatosAlControlador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Editar()
        {
            PersonaListDepartamento pld = new PersonaListDepartamento();
            return View(pld);
        }
        [HttpPost]
        public ActionResult PersonaModificada(PersonaListDepartamento pld)
        {
            return View(pld); //Crear un viewModel que herede de persona y que tenga como propiedad añadida el nombre del departamento
        }
    }
}