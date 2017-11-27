using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Listados
{
    public class ListadoPersonasBL
    {
        public List<Persona> getListadoBL()
        {
            ListadoPersonasDAL listadoPersonas = new ListadoPersonasDAL();
            List<Persona> listadoParaUI = listadoPersonas.getPersonas();
            
            return listadoParaUI;
        }
        public Persona getPersona(int id)
        {
            ListadoPersonasDAL listadoPersonas = new ListadoPersonasDAL();

            Persona personaUI =listadoPersonas.getPersona(id);

            return personaUI;
        }

        public void updatePersona(Persona p)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            listado.updatePersona(p);
        }
        public void deletePersona(int id)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            listado.deletePersona(id);
        }
        public void insertPersona(Persona p)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            listado.insertPersona(p);
        }
    }
}
