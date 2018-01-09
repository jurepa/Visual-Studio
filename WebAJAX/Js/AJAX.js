window.onload = inicializaEventos;

function inicializaEventos()
{
    document.getElementById("btnHola").addEventListener("click",SaludaCrack,false);
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