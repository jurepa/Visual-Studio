using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasarDatosAlControlador.Models.Entities
{
    public class Departamento
    {
        public int idDepartamento { get; set; }

        public string nombre { get; set; }
        public Departamento()
        {
            this.idDepartamento = 0;
            this.nombre = "";
        }
        public Departamento(int id, string nombre)
        {
            this.idDepartamento = id;
            this.nombre = nombre;
        }
    }
}