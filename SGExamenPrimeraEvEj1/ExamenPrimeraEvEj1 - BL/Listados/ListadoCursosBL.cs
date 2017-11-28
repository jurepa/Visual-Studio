using ExamenPrimeraEvEj1___DAL.Listados;
using ExamenPrimeraEvEj1___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvEj1___BL.Listados
{
    public class ListadoCursosBL
    {
        public List<Curso> listado;
        public ListadoCursosBL()
        {
            ListadoCursosDAL listado = new ListadoCursosDAL();
            this.listado = listado.getCursos();
        }
        /// <summary>
        /// Método que te devuelve el listado de cursos
        /// </summary>
        /// <returns></returns>
        public List<Curso>getCursosBL()
        {
            ListadoCursosDAL listado = new ListadoCursosDAL();
            this.listado = listado.getCursos();
            return this.listado;
        }
    }
}
