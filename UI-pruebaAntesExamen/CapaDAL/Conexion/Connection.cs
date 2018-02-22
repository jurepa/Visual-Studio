using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Conexion
{
    public class Connection
    {
        public Uri uriAPI { get; set; }
        public Connection()
        {
            uriAPI = new Uri("http://localhost:62990/api/personajes/");
        }
    }
}
