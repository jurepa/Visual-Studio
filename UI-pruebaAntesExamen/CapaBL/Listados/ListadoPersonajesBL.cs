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
        public async Task<List<Personaje>> getPersonajesBL()
        {
            return await new ListadoPersonajesDAL().getPersonajes();
        }

        public async Task<Personaje> getPersonajeBL(int idPersonaje)
        {
            return await new ListadoPersonajesDAL().getPersonaje(idPersonaje);
        }
    }
}
