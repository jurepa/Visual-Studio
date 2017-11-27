using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_BL.Listados
{
    public class ListadoDepartamentoBL
    {
        public List<Departamento> getListadoBL()
        {
            ListadoDepartamentosDAL listadoDepartamento = new ListadoDepartamentosDAL();
            List<Departamento> listadoParaUI = listadoDepartamento.getDepartamentos();

            return listadoParaUI;
        }
    }
}
