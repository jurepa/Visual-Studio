using PasarDatosAlControlador.Models;
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
            Persona persona = new Persona();
            persona.idPersona = 1;
            persona.nombre = "Pablo";
            persona.apellidos = "Jaranator-3000 Alpha 2.0";
            persona.telefono = "no je ni lo k e un tlfono hulio";
            persona.direccion = "Mi casa";
            persona.fechaNac = new DateTime(1998,03,19);
            return View(persona);
        }
        [HttpPost]
        public ActionResult PersonaModificada(Persona persona)
        {
            return View(persona);
        }
    }
}