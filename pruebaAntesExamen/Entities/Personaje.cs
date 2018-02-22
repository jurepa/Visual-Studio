using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Personaje
    {
        public int idPersonaje { get; set; }
        public string nombre { get; set; }
        public string alias { get; set; }
        public double vida { get; set; }
        public double regeneracion { get; set; }
        public double danno { get; set; }
        public double armadura { get; set; }
        public double velAtaque { get; set; }
        public double resistencia { get; set; }
        public double velMovimiento { get; set; }
    }
}
