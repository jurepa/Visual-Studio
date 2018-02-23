using Capa_DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Listados
{
    public class ListadoCombatesDAL
    {
        public List<Combate> listadoCombates { get; set; }
        public ListadoCombatesDAL()
        {
            this.listadoCombates = new List<Combate>();
        }
        /// <summary>
        /// Devuelve un listado de combates
        /// </summary>
        /// <returns></returns>
        public List<Combate> getListadoCombatesDAL()
        {
            SqlDataReader lector;
            Combate combate;
            SqlCommand consulta = new SqlCommand();
            Connection cx = new Connection();
            try
            {
                consulta.Connection = cx.conexion;
                consulta.CommandText = "Select*from combates";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        combate = new Combate();
                        combate.idCombate = (int)lector["idCombate"];
                        combate.fechaCombate = (DateTime)lector["fechaCombate"];
                        this.listadoCombates.Add(combate);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();
            return this.listadoCombates;
        }
    }
}
