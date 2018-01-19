window.addEventListener("load", inicia);

function inicia()
{
    pintarTabla();
    document.getElementById("borrarPokemon").addEventListener("click", borrarPokemon, false);
    //botones borrar guardar addListener
    
}

function borrarPokemon()
{
    if (document.getElementById("idPokemon").value == "" || document.getElementById("idPokemon").value == null) {

        document.getElementById("textoError").innerHTML = "<span style='color: red;'>Pon algún id pls</span>";
    }
    else if (comprobarSiExiste() == false) {

        document.getElementById("textoError").innerHTML = "<span style='color: red;'>No existe un pokemon con ese id</span>";
    }
    else
    {
        document.getElementById("textoError").innerHTML = "";
        //Aquí borraríamos al pokemon
    }
}
function comprobarSiExiste()
{
    var existe = false;
    var httpRequest = new XMLHttpRequest();
    httpRequest.open("GET", "../api/pokemon/" + document.getElementById("idPokemon").value);
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            if (httpRequest.responseText.length > 4) {
                existe = true;
            }
            else
            {
                existe = false;
            }
            return existe;
        }
    }
    httpRequest.send();
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
            divListadoPokemon.innerHTML = "Nombre"+" "+"Habilidad 1"+" "+"Generacion"+" "+"Habitat"+"<br>";
            var arrayPokemon = JSON.parse(httpRequest.responseText);
            for (var i = 0; i < arrayPokemon.length; i++)
            {
                var pokemon = new Pokemon();
                pokemon = arrayPokemon[i];
                divListadoPokemon.innerHTML = divListadoPokemon.innerHTML + "<br>" + pokemon.nombrePokemon + " " + pokemon.habilidad1 + " " + pokemon.generacion + " " + pokemon.habitat+"<br>";
            }
        }
    }
    httpRequest.send();


}