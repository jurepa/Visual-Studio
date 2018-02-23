using Capa_DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoCategoriasPremiosBL
    {
        public List<CategoriasPremios> getListadoCategoriasPremiosBL()
        {
            return new ListadoCategoriasPremiosDAL().getListadoCategoriasPremiosDAL();
        }
    }
}
