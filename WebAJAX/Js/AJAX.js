window.onload = inicializaEventos;

function inicializaEventos()
{
    document.getElementById("btnHola").addEventListener("click", SaludaCrack, false);
    document.getElementById("btnListaXML").addEventListener("click", MuestraXML, false);
}

function SaludaCrack()
{
    //PASO 1: Instanciar objeto

    var miPeticion = new XMLHttpRequest();

    //PASO 2: Preparar la petición
    miPeticion.open("GET", "../Server/HolaMundo.html", true);

    //PASO 3: Cabeceras(No hace falta en GET)
    //PASO 4: Preparar los cambios de estado

    miPeticion.onreadystatechange = function ()
    {
        document.getElementById("divSaludo").innerHTML="Cargando...................";
        //PASO 6: Tratamiento de la información recibida
        if (miPeticion.readyState == 4 && miPeticion.status == 200)//Si el servidor llega al readyState 4 y el servidor da el codigo OK
        {
            document.getElementById("divSaludo").innerHTML = miPeticion.responseText;
        }
        alert(miPeticion.readyState + " " + miPeticion.status);
    }

    //PASO 5: Enviar la solicitud
    miPeticion.send();
}

function MuestraXML()
{
    var miPeticion = new XMLHttpRequest();

    miPeticion.open("GET", "../Server/Personas.xml", true);
    miPeticion.onreadystatechange = function ()
    {
        document.getElementById("divPersonasXML").innerHTML = "Cargando.........................";
        if (miPeticion.readyState == 4 && miPeticion.status == 200)//Si el servidor llega al readyState 4 y el servidor da el codigo OK
        {
            var table = document.createElement("table");
            var tr = document.createElement("tr");
            var tdNombre = document.createElement("td");
            var tdApellido = document.createElement("td");
            var td1 = document.createElement("td");
            tdNombre.innerHTML = "Nombres";
            tdApellido.innerHTML = "Apellidos";
            tr.appendChild(tdNombre);
            tr.appendChild(tdApellido);
            table.appendChild(tr);
            
            //setAttributes border
            
            var misDatosXML = miPeticion.responseXML;
            //document.getElementById("divPersonasXML").innerHTML = misDatosXML.getElementsByTagName("persona")[1].getElementsByTagName("nombre")[0].firstChild.nodeValue;
            var arrayPersonas = misDatosXML.getElementsByTagName("persona");
            for (var i = 0; i < arrayPersonas.length; i++)
            {
                var persona = arrayPersonas[i];
                var fila = table.insertRow(i);
                for (var j = 0; j < persona.childNodes.length; j++)
                {

                        if (persona.childNodes[j].nodeType === 1)
                        {
                            var td1 = document.createElement("td");
                            td1.innerHTML = persona.childNodes[j].nodeValue;
                            table.appendChild(td1);
                        }                   
                }
                //var td1 = document.createElement("td");
                //td1.innerHTML = persona.getElementsByTagName("nombre")[0].firstChild.nodeValue;
                //var td2 = document.createElement("td");
                //td2.innerHTML = persona.getElementsByTagName("apellidos")[0].firstChild.nodeValue;
                //fila.appendChild(td1);
                //fila.appendChild(td2);
                //table.appendChild(fila);
            }
            document.getElementById("divPersonasXML").appendChild(table);
        }
        //alert(miPeticion.readyState + " " + miPeticion.status);
    }
    miPeticion.send();

}