using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _17_CRUD_Personas_UWP_ET;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace _17_CRUD_Personas_UWP_DAL
{
    public class ListadoPersonasDAL
    {
        public List<Persona> listado { get; set; }

        public ListadoPersonasDAL()
        {
            this.listado = new List<Persona>();
        }
        public async Task<List<Persona>> getPersonas()
        {
            Connection connection = new Connection();
            HttpClient httpClient = new HttpClient();
            try
            {
                //Task<string> stringJson = httpClient.GetStringAsync(connection.uri);
                //string listadoo = await stringJson;
                string listadoJson =await httpClient.GetStringAsync(connection.uri);

                httpClient.Dispose();
                this.listado = JsonConvert.DeserializeObject<List<Persona>>(listadoJson);
                connection.closeConnection();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return this.listado;
        }
        public async Task<Persona> getPersona(int id)
        {
            Connection cx = new Connection();
            Persona p =null;
            HttpClient httpClient = new HttpClient();
            try
            {
                string personaJson = await httpClient.GetStringAsync(new Uri(cx.uri + "api/persona/" + id));
                httpClient.Dispose();
                p= JsonConvert.DeserializeObject<Persona>(personaJson);
                cx.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }

            return p;
        }

        public async Task<HttpStatusCode> updatePersona(Persona p)
        {
            Connection cx = new Connection();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpStringContent contenido = null;
            HttpStatusCode code = new HttpStatusCode();
            try
            {
                string body = JsonConvert.SerializeObject(p);
                contenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                response = await httpClient.PutAsync(new Uri(cx.uri + "api/persona/" + p.idPersona), contenido);
                code = response.StatusCode;
                cx.closeConnection();
            }
            catch (SqlException e)
            {
                throw;
            }
            return code;
        }
        public async Task<HttpStatusCode> deletePersona(int id)
        {
            Connection cx = new Connection();
            HttpStatusCode responseCode = new HttpStatusCode();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpClient httpClient = new HttpClient();
            try
            {
                response=await httpClient.DeleteAsync(new Uri(cx.uri+"api/persona/"+id));
                responseCode = response.StatusCode;
                cx.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }
            return responseCode;
        }
        public async Task<HttpStatusCode> insertPersona(Persona p)
        {
            Connection cx = new Connection();
            HttpStatusCode responseCode = new HttpStatusCode();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpClient httpClient = new HttpClient();
            HttpStringContent contenido = null;
            try
            {

                string personaString = JsonConvert.SerializeObject(p);
                contenido = new HttpStringContent(personaString,Windows.Storage.Streams.UnicodeEncoding.Utf8,"application/json");
                response =await httpClient.PostAsync(new Uri(cx.uri + "api/persona"),contenido);
                responseCode = response.StatusCode;
                cx.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }
            return responseCode;
        }
    }
}
