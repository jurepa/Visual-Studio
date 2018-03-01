/*
README!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

-Funciona todo, solo tengo la espina clavada de que no he podido borrar el personaje correspondiente del array cuando quito
el check de un checkbox, ya que la verdad es que no sé muy bien cómo funcionan los Arrays en js, solo sabía que erán dinámicos.
La cosa es que no sé si funcionan como ArrayLists o otro tipo de colección y por eso no he podido borrar los personajes cuando quitas
el check, pero bueno, todo funciona.



*/

//alert("dd");
window.addEventListener("load", inicia);

var checkBoxesTotales = 0;
var checkBoxesCheckeados = 0;
var indiceArrayPersonajes = 0;
var personajesSeleccionados = new Array; //Este array contendrá los personajes a mostrar
/*
Pinta la tabla y le añade un metodo al evento click del boton de mostrar detalles
*/
function inicia()
{
    pintarTabla();
    document.getElementById("btnMostrarDetalles").addEventListener("click",muestraDetalles);
}
/*
Se encarga de pintar la tabla realizando la respectiva llamada de AJAX, además contiene la función anónima para controlar el checkeo de
los checkboxes
*/
function pintarTabla()
{
    var divTablaPersonajes = document.getElementById("tablaPersonajes");
    var tabla = document.createElement("table");
    tabla.id = "tablaPersonajes";
    tabla.border = "1";
    var trCabecera = document.createElement("tr");
    var thNombre = document.createElement("th");
    thNombre.innerHTML = "Nombre del personaje";
    trCabecera.appendChild(thNombre);
    tabla.appendChild(trCabecera);
    divTablaPersonajes.appendChild(tabla);
    var peticion = new XMLHttpRequest();
    peticion.open("GET", "../api/personajes");
    peticion.onreadystatechange = function()
    {
        if (peticion.readyState == 4 && peticion.status==200)
        {
            var arrayPersonajes = JSON.parse(peticion.responseText);

            for (var i = 0; i < arrayPersonajes.length; i++)
            {
                var personaje = arrayPersonajes[i];
                var tr = document.createElement("tr");
                var td = document.createElement("td");
                var tdCheckBox = document.createElement("td");
                var checkBox = document.createElement("input");
                checkBox.type = "checkbox";
                checkBox.id = i + 1;             
                checkBox.addEventListener("change", function ()
                {
                    var checkBoxCambiado = document.getElementById(this.id); //Conseguimos el checkbox que llamó a la funcion

                    if (checkBoxCambiado.checked == false) {
                        checkBoxesCheckeados--;

                    }
                    else if (checkBoxCambiado.checked == true)
                    {
                        checkBoxesCheckeados++;
                        if (checkBoxesCheckeados > 4) { //Si se selecciona un quinto checkbox, le quita el check y salta el alert
                            alert("No se pueden seleccionar más de 4 personajes a la vez, aunque se seleccione no se mostrará");
                            checkBoxCambiado.checked = false;
                        }
                        else if (personajesSeleccionados.length<4) //Si hay menos de 4 pokemons en el array
                        {
                            getDatosPokemon(checkBoxCambiado.id);
                        }
                    }

                });
                tdCheckBox.appendChild(checkBox);
                checkBoxesTotales++;
                td.innerHTML = personaje.nombre;
                tr.appendChild(td);
                tr.appendChild(tdCheckBox);
                tabla.appendChild(tr);

            }

        }

    }
    peticion.send();
}

//function comprobarCheckeo(idCheckBox)
//{
//    var checkBox = document.getElementById(idCheckBox)
//    if (checkBox != null) {
//        if (checkBox.checked == false) {
//            checkBoxesCheckeados++;
//            if (checkBoxesCheckeados >= 4) {
//                alert("No se pueden seleccionar más de 4 personajes a la vez");
//            }
//            else {
//                checkBox.checked == true;
//            }

//        }
//    }
//}
/*
Realiza otra llamada a AJAX para obtener los datos del personaje correspondiente y lo añade al array de personajes a mostrar
*/
function getDatosPokemon(idPokemon)
{
    var peticion = new XMLHttpRequest();
    peticion.open("GET", "../api/personajes/" + idPokemon);
    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4 && peticion.status == 200) {
            var personaje = JSON.parse(peticion.responseText);
            personajesSeleccionados[indiceArrayPersonajes] = personaje;
            indiceArrayPersonajes++;
        }
    }
    peticion.send();
}
/*
Se encarga de mostrar los detalles de cada personaje que haya en el array
*/
function muestraDetalles()
{
    var viejoDivDetalles = document.getElementById("detalles"); //Aquí borramos el div de detalles antiguo y lo volvemos a crear, para así borrar los detalles de los personajes anteriores
    viejoDivDetalles.remove();
    var divDetalles = document.createElement("div");
    divDetalles.id="detalles"
    document.getElementById("body").appendChild(divDetalles);
    if (personajesSeleccionados.length == 0) {  //Si no se ha elegido ningun personaje
        alert("No hay personajes seleccionados");
    }
    else
    {
        
        var br = document.createElement("br");
        for (var i = 0; i < personajesSeleccionados.length; i++)
        {
            var personaje = personajesSeleccionados[i];
            var imgPersonaje = document.createElement("img");
            var nombre = document.createElement("p");
            nombre.innerHTML = "Nombre: " + personaje.nombre;
            var alias = document.createElement("p");
            alias.innerHTML = "Alias: " + personaje.alias;
            var vida = document.createElement("p");
            vida.innerHTML = "Vida: " + personaje.vida;
            var regeneracion = document.createElement("p");
            regeneracion.innerHTML = "Regeneracion: " + personaje.regeneracion;
            var danno = document.createElement("p");
            danno.innerHTML = "Daño: "+personaje.danno;
            var armadura = document.createElement("p");
            armadura.innerHTML ="Armadura: "+personaje.armadura;
            var velAtaque = document.createElement("p");
            velAtaque.innerHTML = "velAtaque: " + personaje.velAtaque;
            var resistencia = document.createElement("p");
            resistencia.innerHTML = "Resistencia: " + personaje.resistencia;
            var velMovimiento = document.createElement("p");
            velMovimiento.innerHTML = "velMovimiento: " + personaje.velMovimiento;
            var hr = document.createElement("hr");
            imgPersonaje.setAttribute("src", "../Imagenes/" + personaje.nombre + ".png");
            divDetalles.appendChild(imgPersonaje);
            divDetalles.appendChild(br);
            divDetalles.appendChild(nombre);
            divDetalles.appendChild(br);
            divDetalles.appendChild(alias);
            divDetalles.appendChild(br);
            divDetalles.appendChild(vida);
            divDetalles.appendChild(br);
            divDetalles.appendChild(regeneracion);
            divDetalles.appendChild(br);
            divDetalles.appendChild(danno);
            divDetalles.appendChild(br);
            divDetalles.appendChild(armadura);
            divDetalles.appendChild(br);
            divDetalles.appendChild(velAtaque);
            divDetalles.appendChild(br);
            divDetalles.appendChild(resistencia);
            divDetalles.appendChild(br);
            divDetalles.appendChild(velMovimiento);
            divDetalles.appendChild(br);
            divDetalles.appendChild(hr);
            divDetalles.appendChild(br);
        }
        //Inicializamos todo a 0 otra vez, incluido los checkboxes
        personajesSeleccionados = new Array; 
        indiceArrayPersonajes = 0;
        checkBoxesCheckeados = 0;
        for (var i = 0; i <= checkBoxesTotales; i++)
        {
            var checkBox = document.getElementById(i+1);
            checkBox.checked = false;
        }
    }
}