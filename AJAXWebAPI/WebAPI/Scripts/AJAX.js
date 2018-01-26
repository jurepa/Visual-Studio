window.addEventListener("load", inicia);

function inicia() {
    pintarTabla();
    document.getElementById("borrarPokemon").addEventListener("click", comprobarSiExiste, false);
    document.getElementById("btnAddPokemon").addEventListener("click",mostrarCampos,false);
    //botones borrar guardar addListener

}
function mostrarCampos()
{
    var divAddPokemon = document.getElementById("addPokemon");
    var txtNombre = document.createElement("input");
    txtNombre.type = "text";
    txtNombre.placeholder="Nombre Pokemon";
    divAddPokemon.appendChild(txtNombre);
}

function borrarPokemon(existe) {
    if (document.getElementById("idPokemon").value == "" || document.getElementById("idPokemon").value == null || isNaN(document.getElementById("idPokemon").value)) {

        document.getElementById("textoError").innerHTML = "<span style='color: red;'>Pon algún id pls</span>";
    }
    else if (existe == false) { //El método realiza un proceso asíncrono, por lo que mientras comprobarSiExiste realiza su funcion, este método sigue progresando aunque no haya respuesta

        document.getElementById("textoError").innerHTML = "<span style='color: red;'>No existe un pokemon con ese id</span>";
    }
    else {
        var httpRequest = new XMLHttpRequest();
        document.getElementById("textoError").innerHTML = "";
        httpRequest.open("DELETE", "../api/pokemon/" + document.getElementById("idPokemon").value);
        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState == 4 && httpRequest.status == 204) {
                alert("Pokemon borrado");
                pintarTabla();
            }

        }
        httpRequest.send();

    }
}
function comprobarSiExiste() {
    var existe = false;
    var httpRequest = new XMLHttpRequest();
    httpRequest.open("GET", "../api/pokemon/" + document.getElementById("idPokemon").value, false);
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            if (httpRequest.responseText.length > 4) {
                existe = true;
            }
            else
            {
                existe = false;
            }
            borrarPokemon(existe);
        }
    }
    httpRequest.send();
    //if (httpRequest.readyState == 4 && httpRequest.status == 200) {
    //    if (httpRequest.responseText.length > 4) {
    //        existe = true;
    //    }
    //    else {
    //        existe = false;
    //    }
    //    return existe;
    //}

}
function pintarTabla() {
    var httpRequest = new XMLHttpRequest();
    var divListadoPokemon = document.getElementById("listadoPokemon");
    httpRequest.open("GET", "../api/pokemon");
    httpRequest.onreadystatechange = function () {
        document.getElementById("listadoPokemonJSON").innerHTML = "Cargando.................";
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            document.getElementById("listadoPokemonJSON").innerHTML = httpRequest.responseText;
            divListadoPokemon.innerHTML = "Nombre" + " " + "Habilidad 1" + " " + "Generacion" + " " + "Habitat" + "<br>";
            var arrayPokemon = JSON.parse(httpRequest.responseText);
            for (var i = 0; i < arrayPokemon.length; i++) {
                var pokemon = new Pokemon();
                pokemon = arrayPokemon[i];
                divListadoPokemon.innerHTML = divListadoPokemon.innerHTML + "<br>" + pokemon.nombrePokemon + " " + pokemon.habilidad1 + " " + pokemon.generacion + " " + pokemon.habitat + "<br>";
            }
        }
    }
    httpRequest.send();


}