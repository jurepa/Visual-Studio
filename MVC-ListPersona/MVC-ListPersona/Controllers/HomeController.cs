using MVC_ListPersona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ListPersona.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Devolverá la vista Index al ejecutar la app
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Nos devolverá la vista del listado de personas al pulsar el link
        /// </summary>
        /// <returns></returns>
        public ActionResult ListadoPersonas()
        {
            ListPersona listado = new ListPersona();
            return View(listado);
        }
    }
}