using Capa_DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoCasasBL
    {
        public List<Casa> getListadoCasasBL()
        {
            return new ListadoCasasDAL().getListadoCasasDAL();
        }
    }
}
