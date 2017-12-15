using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCore_DAL;
using WebApiCore_ET;

namespace WebApiCore_BL
{
    public class ListadoPokemonBL
    {
        public List<Pokemon> getListadoBL()
        {
            ListadoPokemonDAL listadoPokemon = new ListadoPokemonDAL();
            List<Pokemon> listadoParaUI = listadoPokemon.getPokemons();

            return listadoParaUI;
        }
        public Pokemon getPokemon(int id)
        {
            ListadoPokemonDAL listadoPokemon = new ListadoPokemonDAL();

            Pokemon PokemonUI = listadoPokemon.getPokemon(id);

            return PokemonUI;
        }

        public void updatePokemon(int id, Pokemon p)
        {
            ListadoPokemonDAL listado = new ListadoPokemonDAL();
            listado.updatePokemon(id,p);
        } 
        public void deletePokemon(int id)
        {
            ListadoPokemonDAL listado = new ListadoPokemonDAL();
            listado.deletePokemon(id);
        }
        public void insertPokemon(Pokemon p)
        {
            ListadoPokemonDAL listado = new ListadoPokemonDAL();
            listado.insertPokemon(p);
        }
    }
}
