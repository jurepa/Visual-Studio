using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Personas_UI.ViewModels
{
    public class PersonaConListDepartamento
    {
        public List<Departamento> listado { get; set; }
        public Persona persona { get; set; }

        public PersonaConListDepartamento()
        {
            listado = new ListadoDepartamentoBL().getListadoBL();
            //persona = new Persona();
        }
        public PersonaConListDepartamento(int id)
        {
            listado = new ListadoDepartamentoBL().getListadoBL();
            persona = new ListadoPersonasBL().getPersona(id);
        }
    }
}