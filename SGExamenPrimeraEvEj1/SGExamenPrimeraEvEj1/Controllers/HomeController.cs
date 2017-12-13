using ExamenPrimeraEvEj1___BL.Listados;
using ExamenPrimeraEvEj1___ET;
using SGExamenPrimeraEvEj1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGExamenPrimeraEvEj1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Aquí instanciamos el viewModel y se lo pasamos a la vista
        /// </summary>
        /// <returns></returns>
        // GET: Home
        public ActionResult Index()
        {
            ListadoCursosConIdCursoSeleccionado listado = new ListadoCursosConIdCursoSeleccionado();

            return View(listado);
        }
        /// <summary>
        /// Método que se ejecutará al seleccionar el curso, lo que haremos aquí será filtrar el
        /// </summary>
        /// <param name="listado"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ListadoCursosConIdCursoSeleccionado listado)
        {
            ListadoAlumnosBL listadoAlumnos = new ListadoAlumnosBL();
            List<Alumno> listaFiltrada = listadoAlumnos.getListadoAlumnosCursoBL(listado.idCursoSeleccionado);
            return View("ListAlumnos", listaFiltrada);
        }

        /// <summary>
        /// Método que se ejecuta al pulsar en el enlace Asignar Beca, lo que hace es devolver una vista con los datos
        /// del alumno y un campo de texto inputType number para editar la beca
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public ActionResult EditBeca(int idAlumno)
        {
            ListadoAlumnosBL listado = new ListadoAlumnosBL();
            AlumnoConBecaInt a = new AlumnoConBecaInt();
            a.alumno = listado.getAlumno(idAlumno);

            return View(a);
        }
        /// <summary>
        /// Método que se ejecuta cuando queremos guardar la beca registrada.
        /// Si el model no es valido te redirige a la misma pagina y muestra un mensaje de error.
        /// Si hay algun error en el servidor te lleva a una vista de error
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditBeca(AlumnoConBecaInt a)
        {
            if (!ModelState.IsValid)
            {
                return View("EditBeca", a);
            }
            else
            {
                Alumno alumno = null;
                ListadoAlumnosBL listado = null;
                try
                {
                    alumno = a.alumno;
                    alumno.beca = Convert.ToDecimal(a.becaINT);
                    listado = new ListadoAlumnosBL();
                    listado.updateAlumno(alumno);
                }
                catch (Exception)
                {
                    return View("ErrorPage");
                }
                List<Alumno> listaFiltrada = listado.getListadoAlumnosCursoBL(alumno.idCurso);
                return View("ListAlumnos", listaFiltrada);
            }
        }

        
    }
}