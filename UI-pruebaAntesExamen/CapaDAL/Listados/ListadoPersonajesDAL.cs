using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL.Conexion;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace CapaDAL.Listados
{
    public class ListadoPersonajesDAL
    {
        public List<Personaje> personajes { get; set; }

        public ListadoPersonajesDAL()
        {
            this.personajes = new List<Personaje>();
        }

        public async Task<List<Personaje>> getPersonajes()
        {
            Connection cx = new Connection();
            HttpClient httpClient = new HttpClient();
            try
            {
                string listadoJson = await httpClient.GetStringAsync(cx.uriAPI);
                httpClient.Dispose();
                this.personajes = JsonConvert.DeserializeObject<List<Personaje>>(listadoJson);
            }
            catch (Exception e)
            {
                throw e;
            }
            return this.personajes;
        }

        public async Task<Personaje> getPersonaje(int idPersonaje)
        {
            Connection cx = new Connection();
            HttpClient httpClient = new HttpClient();
            Personaje p=new Personaje();
            try
            {
                string personajeJson = await httpClient.GetStringAsync(new Uri(cx.uriAPI.ToString()+idPersonaje));
                httpClient.Dispose();
                p = JsonConvert.DeserializeObject<Personaje>(personajeJson);
            }
            catch (Exception e)
            {
                throw e;
            }
            return p;
        }
    }
}
