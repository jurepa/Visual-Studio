using ExamenPrimeraEvEj1___BL.Listados;
using ExamenPrimeraEvEj1___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGExamenPrimeraEvEj1.ViewModel
{
    /// <summary>
    /// Este viewModel contiene el listado de todos los cursos y el id del curso seleccionado, cuyo valor dependerá de
    /// lo que hayamos elegido en el DropDownListFor
    /// </summary>
    public class ListadoCursosConIdCursoSeleccionado
    {
        public List<Curso> listado { get; set; }
        public int idCursoSeleccionado { get; set; }
        public ListadoCursosConIdCursoSeleccionado()
        {
            this.listado = new ListadoCursosBL().getCursosBL();
        }
    }
}