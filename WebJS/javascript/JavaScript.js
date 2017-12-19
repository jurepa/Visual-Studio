window.onload = inicializaEventos;

function inicializaEventos()
{
    document.getElementById("btnSaludar").addEventListener("click",saludar,false);
}

function saludar()
{
    var nombre = document.getElementById("txtNombre").value;
    var fechaString = document.getElementById("txtFecha").value;
    var fechaDate = Date.parse(fechaString);
    if (nombre === "") 
    {
        document.getElementById("labelErrorNombre").innerHTML = "Error";
    }
    else
    {
        document.getElementById("labelErrorNombre").innerHTML = "";
    }
    if (isNaN(fechaDate)) {
        document.getElementById("labelErrorFecha").innerHTML = "Mala fecha loquete, el formato es mm/dd/yyyy";
    }
    else
    {
        document.getElementById("labelErrorFecha").innerHTML = "Qué buena fesha io";
    }
    if (nombre != "" && !isNaN(fechaDate))
    {
        alert("Hola " + nombre + " crack, máquina, fiera, leyenda, maestro, machote, churraca. Naciste el " + new Date(fechaDate).toDateString());
    }
}