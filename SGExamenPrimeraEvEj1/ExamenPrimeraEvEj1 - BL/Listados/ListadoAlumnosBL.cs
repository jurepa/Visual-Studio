using ExamenPrimeraEvEj1___DAL.Listados;
using ExamenPrimeraEvEj1___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvEj1___BL.Listados
{
    public class ListadoAlumnosBL
    {
        public List<Alumno> listado { get; set; }
        public ListadoAlumnosBL()
        {
            this.listado = new List<Alumno>();
        }
        /// <summary>
        /// Método que nos devolverá un listado de alumnos dependiendo del id de curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<Alumno> getListadoAlumnosCursoBL(int idCurso)
        {
            this.listado= new ListadoAlumnosDAL().getListadoAlumnosCurso(idCurso);
            return this.listado;
        }
        /// <summary>
        /// Método que nos devuelve un alumno dependiendo su id
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public Alumno getAlumno(int idAlumno)
        {
            return new ListadoAlumnosDAL().getAlumno(idAlumno);
        }
        /// <summary>
        /// Método que actualiza la beca de un alumno en la base de datos
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public void updateAlumno(Alumno a)
        {
            ListadoAlumnosDAL listado = new ListadoAlumnosDAL();
            listado.updateBecaAlumno(a);
        }


    }
}
