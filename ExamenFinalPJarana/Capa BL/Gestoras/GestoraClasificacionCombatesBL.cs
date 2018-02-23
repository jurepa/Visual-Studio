using Capa_DAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraClasificacionCombatesBL
    {
        public void insertClasificacionCombate(ClasificacionCombate resultado)
        {
            GestoraClasificacionCombatesDAL gestora = new GestoraClasificacionCombatesDAL();
            gestora.insertClasificacionCombate(resultado);
        }
    }
}
