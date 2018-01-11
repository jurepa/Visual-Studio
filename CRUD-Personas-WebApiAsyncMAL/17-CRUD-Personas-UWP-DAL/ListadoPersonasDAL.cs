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
        public List<Pokemon> listado { get; set; }

        public ListadoPersonasDAL()
        {
            this.listado = new List<Pokemon>();
        }
        public async Task<List<Pokemon>> getPersonas()
        {
            Connection connection = new Connection();
            HttpClient httpClient = new HttpClient();
            try
            {
                //Task<string> stringJson = httpClient.GetStringAsync(connection.uri);
                //string listadoo = await stringJson;
                string listadoJson =await httpClient.GetStringAsync(new Uri(connection.uri+"api/pokemon"));

                httpClient.Dispose();
                this.listado = JsonConvert.DeserializeObject<List<Pokemon>>(listadoJson);
                connection.closeConnection();
            }
            catch (Exception e)
            {
                throw;
            }
            return this.listado;
        }
        public async Task<Pokemon> getPersona(int id)
        {
            Connection cx = new Connection();
            Pokemon p =null;
            HttpClient httpClient = new HttpClient();
            try
            {
                string personaJson = await httpClient.GetStringAsync(new Uri(cx.uri + "api/Pokemon/" + id));
                httpClient.Dispose();
                p= JsonConvert.DeserializeObject<Pokemon>(personaJson);
                cx.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }

            return p;
        }

        public async Task<HttpStatusCode> updatePersona(Pokemon p)
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
                response = await httpClient.PutAsync(new Uri(cx.uri + "api/Pokemon/" + p.idPokemon), contenido);
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
                response=await httpClient.DeleteAsync(new Uri(cx.uri+"api/Pokemon/"+id));
                responseCode = response.StatusCode;
                cx.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }
            return responseCode;
        }
        public async Task<HttpStatusCode> insertPersona(Pokemon p)
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
                response =await httpClient.PostAsync(new Uri(cx.uri + "api/Pokemon"),contenido);
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
