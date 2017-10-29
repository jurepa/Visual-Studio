using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueryPrimeraVez.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(bool? miPrimeraVez)
        {
            if (miPrimeraVez == false)
            {
                ViewData["primeraVez"] = "Ya no es tu primera vez";
                ViewData["esMiPrimeraVez"] = miPrimeraVez;
            }
            else
            {
                ViewData["primeraVez"] = "Es tu primera vez";
                miPrimeraVez = false;
                ViewData["esMiPrimeraVez"] = miPrimeraVez;
            }
            return View();
        }
    }
}