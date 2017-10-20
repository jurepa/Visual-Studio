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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListadoPersonas()
        {
            ListPersona listado = new ListPersona();
            return View(listado);
        }
    }
}