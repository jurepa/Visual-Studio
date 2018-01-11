using _17_CRUD_Personas_UWP_DAL;
using _17_CRUD_Personas_UWP_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace _17_CRUD_Personas_UWP_BL
{
    public class ListadoPersonasBL
    {
        public async Task<List<Persona>> getListadoBL()
        {
            ListadoPersonasDAL listadoPersonas = new ListadoPersonasDAL();
            List<Persona> listadoParaUI = null;
            try
            {
                listadoParaUI = await listadoPersonas.getPersonas();
            }
            catch (Exception)
            {
                throw;
            }
            
            return listadoParaUI;
        }
        public async Task<Persona> getPersona(int id)
        {
            ListadoPersonasDAL listadoPersonas = new ListadoPersonasDAL();

            Persona personaUI =await listadoPersonas.getPersona(id);

            return personaUI;
        }

        public async Task<HttpStatusCode> updatePersona(Persona p)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            HttpStatusCode code=await listado.updatePersona(p);
            return code;
        }
        public async Task<HttpStatusCode> deletePersona(int id)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            HttpStatusCode responseCode = new HttpStatusCode();
            responseCode=await listado.deletePersona(id);
            return responseCode;
        }
        public async Task<HttpStatusCode> insertPersona(Persona p)
        {
            ListadoPersonasDAL listado = new ListadoPersonasDAL();
            HttpStatusCode responseCode=await listado.insertPersona(p);
            return responseCode;
        }
    }
}
