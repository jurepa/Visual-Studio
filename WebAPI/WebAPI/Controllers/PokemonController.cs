﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PokemonController : ApiController
    {
        // GET: api/Pokemon
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pokemon/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pokemon
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pokemon/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pokemon/5
        public void Delete(int id)
        {
        }
    }
}
