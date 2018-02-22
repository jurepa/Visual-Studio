using CapaDAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class ListadoPersonajesBL
    {
        public List<Personaje> personajes { get; set; }
        public ListadoPersonajesBL()
        {
            this.personajes = new List<Personaje>();
        }

        public List<Personaje> getPersonajesBL()
        {
            this.personajes= new ListadoPersonajesDAL().getPersonajesDAL();
            return personajes;
        }

        public Personaje getPersonajeBL(int idPersonaje)
        {
            Personaje p = new ListadoPersonajesDAL().getPersonajeDAL(idPersonaje);
            return p;
        }

    }
}
