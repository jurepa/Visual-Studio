using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClasificacionCombate
    {
        public int idCombate { get; set; }
        public int puntos { get; set; }
        public int idLuchador { get; set; }
        public int idCategoriaPremio { get; set; }

    }
}
