using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using WebApiCore_ET;
using WebApiCore_BL;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        // GET api/values
        [HttpGet]
        public ObservableCollection<Pokemon> Get()
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();

            return new ObservableCollection<Pokemon>(listado.getListadoBL());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Pokemon Get(int id)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();

            return listado.getPokemon(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Pokemon value)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();
            listado.insertPokemon(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Pokemon value)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();
            if (listado.getPokemon(id) == null)
            {
                listado.insertPokemon(value);
            }
            else
            {
                listado.updatePokemon(id, value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ListadoPokemonBL listado = new ListadoPokemonBL();
            listado.deletePokemon(id);
        }
    }
}
