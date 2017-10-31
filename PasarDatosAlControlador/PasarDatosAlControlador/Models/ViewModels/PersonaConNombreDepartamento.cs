using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasarDatosAlControlador.Models.ViewModels
{   /// <summary>
    ///VM de Persona que contiene además el nombre del departamento. Hereda de persona 
    /// </summary>
    public class PersonaConNombreDepartamento:Persona
    {
        public string nombreDepartamento { get; set; }
     
    }
}