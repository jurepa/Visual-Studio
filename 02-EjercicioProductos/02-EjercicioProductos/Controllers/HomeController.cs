using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_EjercicioProductos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id) //La interrogación indica un parámetro opcional
        {
            return View();
        }
    }
}