using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;
using System.Data.SqlClient;
using CRUD_Personas_UI.ViewModels;

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
        public ActionResult Edit(int id)
        {
            PersonaConListDepartamento vm = new PersonaConListDepartamento(id);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(PersonaConListDepartamento p)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", p);
            }
            else
            {
                try
                {
                    ListadoPersonasBL listado = new ListadoPersonasBL();
                    listado.updatePersona(p.persona);
                    return RedirectToAction("Index"); //Crear un viewModel que herede de persona y que tenga como propiedad añadida el nombre del departamento
                }
                catch (Exception)
                {
                    return View("ErrorPage");
                }
            }

        }
        public ActionResult Details(int id)
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            Persona persona = listado.getPersona(id);
            return View(persona);
        }

        public ActionResult Delete(int id)
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            Persona persona = listado.getPersona(id);
            return View(persona);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSql(int id)
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            try
            {
                listado.deletePersona(id);
            }
            catch (Exception)
            {
                return View("Error page");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Persona p)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",p);//!!!!!!!!!!!!!!!!!!
            }
            else
            {
                try
                {
                    ListadoPersonasBL listado = new ListadoPersonasBL();
                    listado.insertPersona(p);
                    return RedirectToAction("Index"); //Crear un viewModel que herede de persona y que tenga como propiedad añadida el nombre del departamento
                }
                catch (SqlException)
                {
                    return View("ErrorPage");
                }
            }
        }
    }
}