using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI___BL.Listados;
using WebAPI___ET;

namespace WebAPI.Controllers
{
    public class PokemonController : ApiController
    {
        // GET: api/Pokemon
        public ObservableCollection<Pokemon> Get()
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();
            
            return new ObservableCollection<Pokemon>(listado.getListadoBL());
        }

        // GET: api/Pokemon/5
        public Pokemon Get(int id)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();

            return listado.getPokemon(id);
        }

        // POST: api/Pokemon
        public void Post([FromBody]Pokemon value)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();
            listado.insertPokemon(value);
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
