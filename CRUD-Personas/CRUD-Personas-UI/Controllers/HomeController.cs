using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            List<Persona> listaVista = listado.getListadoBL();
            return View(listaVista);
        }
    }
}