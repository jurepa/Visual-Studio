using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Luchador
    {
        public int idLuchador { get; set; }
        public string nombreLuchador { get; set; }
        public int idCasa { get; set; }

        public Uri fotoCasa { get; set; }
        public Uri fotoPerfil { get; set; }
        public string nombreCasa { get; set; }
    }
}
