window.addEventListener("load", inicia);

function inicia()
{
    pintarTabla();
    //botones borrar guardar addListener
    
}

function pintarTabla()
{
    var httpRequest = new XMLHttpRequest();
    var divListadoPokemon = document.getElementById("listadoPokemon");
    httpRequest.open("GET", "../api/pokemon");
    httpRequest.onreadystatechange = function ()
    {
        document.getElementById("listadoPokemonJSON").innerHTML = "Cargando.................";
        if (httpRequest.readyState == 4 && httpRequest.status == 200)
        {
            document.getElementById("listadoPokemonJSON").innerHTML = httpRequest.responseText;
            divListadoPokemon.innerHTML = "Nombre Pokemons";
            var arrayPokemon = JSON.parse(httpRequest.responseText);
            for (var i = 0; i < arrayPokemon.length; i++)
            {
                var pokemon = new Pokemon();
                pokemon = arrayPokemon[i];
                divListadoPokemon.innerHTML = divListadoPokemon.innerHTML+"<br>"+ pokemon.nombrePokemon+"<br>";
            }
        }
    }
    httpRequest.send();


}