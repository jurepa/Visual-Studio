//Alberto Navarro Gordillo

window.addEventListener("load", cargarCursos);

document.getElementById("btnMetodoEntrada").addEventListener("click", cambiarMetodoEntrada);
document.getElementById("slctCursos").addEventListener("change", llamada);
document.getElementById("btnGuardar").addEventListener("click", checkNotas);

var usandoRaton = false;



function cargarCursos() {    
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../server/alumnos.xml");
    oXML.onreadystatechange = function () {
        if (oXML.readyState == 4 && oXML.status == 200) {            
            var selectBox = document.getElementById("slctCursos");
            var cursos = oXML.responseXML.getElementsByTagName("curso");
            //Crear cursos
            for (var i = 0; i < cursos.length; i++) {
                op = document.createElement("option");
                op.setAttribute("value", cursos[i].getElementsByTagName("codigoCurso")[0].textContent);
                op.textContent = cursos[i].getElementsByTagName("nombreCurso")[0].textContent;
                selectBox.appendChild(op);               
            }

        }
    }
    oXML.send();
    llamada();
}

    function llamada() {
        var oXML = new XMLHttpRequest();
        document.getElementById("contenedor").innerHTML = "Cargando...";

        oXML.open("GET", "../server/alumnos.xml");

        oXML.onreadystatechange = function () {
            if (oXML.readyState < 4) {
                document.getElementById("contenedor").innerHTML = "Cargando..."
            }
            else if (oXML.readyState == 4 && oXML.status == 200) {
                //Obtener alumnos según el curso
                var selectBox = document.getElementById("slctCursos");
                var choice = selectBox.selectedIndex;

                escribirAlumnos(oXML.responseXML, selectBox.options[choice].value);

            } else if (oXML.status == 404) {
                document.getElementById("contenedor").innerHTML = "Error 404: Archivo not found.";
            }
        }
        oXML.send();
        if(usandoRaton)
            cambiarMetodoEntrada;
        
    }
    


    function escribirAlumnos(respXML, curso) {
        //Crear tabla
        var tabla = document.createElement("TABLE");
        tabla.setAttribute("id", "tabla");
        tabla.border = 2;

        var pFila = document.createElement("TR");
        var pColumna = document.createElement("TH");
        var pTexto = document.createTextNode("Alumno");
        pColumna.appendChild(pTexto);
        pFila.appendChild(pColumna);

        pColumna = document.createElement("TH");
        pTexto = document.createTextNode("Nota");
        pColumna.appendChild(pTexto);
        pFila.appendChild(pColumna);
        tabla.appendChild(pFila);


        //Obtener alumnos del curso
        var cursos = respXML.getElementsByTagName("curso");
        var alumnos = null;
        for (var i = 0; i < cursos.length; i++) {
            //Comprobar el curso
            if (cursos[i].firstElementChild.textContent == curso) {
                alumnos = cursos[i].getElementsByTagName("alumno");
            }
        }

        for (var i = 0; i < alumnos.length; i++) {
            var miFila = document.createElement("TR");

            //Añadir Nombres
            var miColumna = document.createElement("TD");
            var miTexto = document.createTextNode(alumnos[i].textContent);
            miColumna.appendChild(miTexto);
            miFila.appendChild(miColumna);

            //Añadir Notas
            miColumna = document.createElement("TD");
            var miCampoDeTexto = document.createElement("input");
            miCampoDeTexto.setAttribute("type", "number");
            miCampoDeTexto.setAttribute("value", "0");
            miCampoDeTexto.setAttribute("min", "0");
            miCampoDeTexto.setAttribute("max", "10");
            miCampoDeTexto.setAttribute("width", "2");
            miCampoDeTexto.setAttribute("id", "notaAlumno"+i.toString());
            miCampoDeTexto.setAttribute("onclick", "ponerNota(\"notaAlumno\" +" +i+")");            
            miColumna.appendChild(miCampoDeTexto);
            miFila.appendChild(miColumna);
            tabla.appendChild(miFila);
        }


        document.getElementById("contenedor").innerText = "";
        document.getElementById("contenedor").appendChild(tabla);
    }


    function ponerNota(alumno) {
        if (usandoRaton)
            document.getElementById(alumno).value = document.getElementById("txtNota").value;
    }


    function checkNotas() {
        var todoOk = true;
        var filas = document.getElementById("tabla").children;
        for (var i = 0; i < filas.length - 1; i++) {
            var input = document.getElementById("notaAlumno" + i);
            if (input.value > 10 || input.value < 0 || input.value == "") {
                todoOk = false;
                //TODO: Cambiar color del value a rojo                
            }
            else {
                //TODO: Cambiar color del value a negro
            }
        }

        if (todoOk)
            alert("Todos los valores están ok")
        else
            alert("Error: valores incorrectos")

    }


    function cambiarMetodoEntrada() {
        if (usandoRaton) {
            //Cambiar a teclado
            usandoRaton = false;
            document.getElementById("txtNota").setAttribute("disabled", "disabled");
            document.getElementById("btnMetodoEntrada").setAttribute("value", "Usar ratón");

            //Permitir modificar campos
            var filas = document.getElementById("tabla").children;
            for (var i = 0; i < filas.length - 1; i++) {
                var input = document.getElementById("notaAlumno" + i);
                input.removeAttribute("readonly");
            }
        }
        else {
            //Cambiar a ratón
            document.getElementById("txtNota").removeAttribute("disabled");
            document.getElementById("btnMetodoEntrada").setAttribute("value", "Usar teclado");
            usandoRaton = true;

            //No permitir modificar campos
            var filas = document.getElementById("tabla").children;
            for (var i = 0; i < filas.length - 1; i++) {
                var input = document.getElementById("notaAlumno" + i);
                input.setAttribute("readonly", "readonly");
            }

        }
    }
