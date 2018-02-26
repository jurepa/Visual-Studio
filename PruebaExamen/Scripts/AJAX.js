window.addEventListener("load", inicia);

function inicia() {
    pintarTabla();
    document.getElementById("borrarPokemon").addEventListener("click", comprobarSiExiste, false);
    document.getElementById("btnAddPokemon").addEventListener("click",mostrarCampos,false);
    //botones borrar guardar addListener

}
function mostrarCampos()
{
    document.getElementById("btnAddPokemon").setAttribute("disabled", "disabled");
    var divAddPokemon = document.getElementById("addPokemon");
    var txtNombre = document.createElement("input");
    txtNombre.id = "nombre";
    txtNombre.type = "text";
    txtNombre.placeholder = "Nombre Pokemon";
    var txtHabilidad = document.createElement("input");
    txtHabilidad.id = "habilidad";
    txtHabilidad.type = "text";
    txtHabilidad.placeholder = "Habilidad";
    var txtGeneracion = document.createElement("input");
    txtGeneracion.id = "generacion";
    txtGeneracion.type = "number";
    txtGeneracion.placeholder = "Generacion";
    var txtHabitat = document.createElement("input");
    txtHabitat.id = "habitat";
    txtHabitat.type = "text";
    txtHabitat.placeholder = "Habitat";
    var btnGuardar = document.createElement("input");
    btnGuardar.type = "button";
    btnGuardar.value = "Guardar";
    btnGuardar.addEventListener("click",insertarPokemon,false);
    divAddPokemon.appendChild(txtNombre);
    divAddPokemon.appendChild(txtHabilidad);
    divAddPokemon.appendChild(txtGeneracion);
    divAddPokemon.appendChild(txtHabitat);
    divAddPokemon.appendChild(btnGuardar);
}
function insertarPokemon()
{
    if (document.getElementById("nombre").textContent != "" || document.getElementById("habitat").textContent != ""
        || document.getElementById("generacion").textContent != "" || document.getElementById("habilidad").textContent!="")
    {
        document.getElementById("textoError").innerHTML = "<span style='color: red;'>Rellene todos los campos por favor</span>";
    }
    else
    {
        document.getElementById("textoError").innerHTML = "";
        var httpRequest = new XMLHttpRequest();

        var pokemon = new Pokemon();
        pokemon.nombrePokemon = document.getElementById("nombre").value;
        pokemon.habilidad1 = document.getElementById("habilidad").value;
        pokemon.generacion = document.getElementById("generacion").value;
        pokemon.habitat = document.getElementById("habitat").value;
        httpRequest.open("POST", "http://localhost:51593/api/pokemon/");
        httpRequest.setRequestHeader("Content-Type", "application/json");
        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState == 4 && httpRequest.status == 204) {
                alert("Pokemon insertado");
                document.getElementById("tablaPokemon").remove();
                pintarTabla();
            }
        }
        httpRequest.send(JSON.stringify(pokemon));
    }
  
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
        httpRequest.open("DELETE", "http://localhost:51593/api/pokemon/" + document.getElementById("idPokemon").value);
        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState == 4 && httpRequest.status == 204) {
                alert("Pokemon borrado");
                document.getElementById("tablaPokemon").remove();
                pintarTabla();
            }

        }
        httpRequest.send();

    }
}
function comprobarSiExiste() {
    var existe = false;
    var httpRequest = new XMLHttpRequest();
    httpRequest.open("GET", "http://localhost:51593/api/pokemon/" + document.getElementById("idPokemon").value, false);
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
    var table = document.createElement("table");
    table.border = "1";
    table.id = "tablaPokemon";
    var tr = document.createElement("tr");
    var thIdPokemon = document.createElement("th");
    thIdPokemon.innerHTML = "idPokemon";
    var thNombre = document.createElement("th");
    thNombre.innerHTML = "Nombre";
    var thHabilidad1 = document.createElement("th");
    thHabilidad1.innerHTML = "Habilidad 1";
    var thGeneracion = document.createElement("th");
    thGeneracion.innerHTML = "Generacion";
    var thHabitat = document.createElement("th");
    thHabitat.innerHTML = "Habitat";
    tr.appendChild(thIdPokemon);
    tr.appendChild(thNombre);
    tr.appendChild(thHabilidad1);
    tr.appendChild(thGeneracion);
    tr.appendChild(thHabitat);
    table.appendChild(tr);
    divListadoPokemon.appendChild(table);
    httpRequest.open("GET", "http://localhost:51593/api/pokemon");
    httpRequest.onreadystatechange = function () {
        //document.getElementById("listadoPokemonJSON").innerHTML = "Cargando.................";
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            //document.getElementById("listadoPokemonJSON").innerHTML = httpRequest.responseText;
            //divListadoPokemon.innerHTML = "Nombre" + " " + "Habilidad 1" + " " + "Generacion" + " " + "Habitat" + "<br>";
            var arrayPokemon = JSON.parse(httpRequest.responseText);
            for (var i = 0; i < arrayPokemon.length; i++) {
                var pokemon = arrayPokemon[i];
                var otraTr = document.createElement("tr");
                var tdIdPokemon = document.createElement("td");
                var tdNombre=document.createElement("td");
                var tdHabilidad1=document.createElement("td");
                var tdGeneracion=document.createElement("td");
                var tdHabitat = document.createElement("td");
                tdIdPokemon.innerHTML = pokemon.idPokemon;
                tdNombre.innerHTML = pokemon.nombrePokemon;
                tdHabilidad1.innerHTML = pokemon.habilidad1;
                tdGeneracion.innerHTML = pokemon.generacion;
                tdHabitat.innerHTML = pokemon.habitat;
                otraTr.appendChild(tdIdPokemon);
                otraTr.appendChild(tdNombre);
                otraTr.appendChild(tdHabilidad1);
                otraTr.appendChild(tdGeneracion);
                otraTr.appendChild(tdHabitat);
                table.appendChild(otraTr);
                //divListadoPokemon.innerHTML = divListadoPokemon.innerHTML + "<br>" + pokemon.nombrePokemon + " " + pokemon.habilidad1 + " " + pokemon.generacion + " " + pokemon.habitat + "<br>";
            }
        }
    }
    httpRequest.send();


}