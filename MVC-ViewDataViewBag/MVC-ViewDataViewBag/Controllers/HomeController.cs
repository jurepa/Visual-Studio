using MVC_ViewDataViewBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ViewDataViewBag.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Persona persona = new Persona();
            DateTime fNacimiento = new DateTime(1998, 3, 19, 21, 0, 0);
            if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 12)
            {
                ViewData["Saludo"] = "Buenos dias";
            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 20)
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenas noches";
            }
            /*if (fNacimiento.Hour >= 5 && fNacimiento.Hour <= 12)
            {
                ViewData["Saludo"] = "Buenos dias";
            }
            else if (fNacimiento.Hour > 12 && fNacimiento.Hour <= 20)
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenas noches";
                
            }*/
            ViewBag.Fecha = DateTime.Now.ToLongDateString();
           
            persona.idPersona = 1;
            persona.nombre = "Pablo";
            persona.apellidos = "Jarana García";
            persona.direccion = "Juego una y me voy, 6 1ºA";
            persona.telefono = "No he tocao un movi en mi vía hulio";
            persona.fechaNac = fNacimiento;
            return View(persona);
        }
    }
}