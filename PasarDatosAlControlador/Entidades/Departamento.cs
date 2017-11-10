using System;
using System.Collections.Generic;
using System.Linq;
namespace Entidades
{   /// <summary>
    /// Clase departamento, con int idDep y string nombre 
    /// </summary>
    public class Departamento
    {
        public int idDepartamento { get; set; }

        public string nombre { get; set; }
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Departamento()
        {
            this.idDepartamento = 0;
            this.nombre = "";
        }
        /// <summary>
        /// Constructor por parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public Departamento(int id, string nombre)
        {
            this.idDepartamento = id;
            this.nombre = nombre;
        }
    }
}