using CapaBL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaAntesExamen.Controllers
{
    public class PersonajesController : ApiController
    {
        // GET: api/Personajes
        public List<Personaje> Get()
        {
            return new ListadoPersonajesBL().getPersonajesBL();
        }

        // GET: api/Personajes/5
        public Personaje Get(int id)
        {
            return new ListadoPersonajesBL().getPersonajeBL(id);
        }

        // POST: api/Personajes
        public HttpResponseMessage Post([FromBody]string value)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.NotImplemented;
            return  response;
        }

        // PUT: api/Personajes/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.NotImplemented;
            return response;
        }

        // DELETE: api/Personajes/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.NotImplemented;
            return response;
        }
    }
}
