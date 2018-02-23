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
    public class ListadoCasasDAL
    {
        public List<Casa> listadoCasas { get; set; }

        public ListadoCasasDAL()
        {
            this.listadoCasas = new List<Casa>();
        }
        /// <summary>
        /// Devuelve el listado de casas
        /// </summary>
        /// <returns></returns>
        public List<Casa> getListadoCasasDAL()
        {
            SqlDataReader lector;
            Casa casa;
            SqlCommand consulta = new SqlCommand();
            Connection cx = new Connection();
            try
            {
                consulta.Connection = cx.conexion;
                consulta.CommandText = "Select*from casas";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        casa = new Casa();
                        casa.idCasa = (int)lector["idCasa"];
                        casa.nombreCasa = (string)lector["nombreCasa"];
                        this.listadoCasas.Add(casa);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();
            return this.listadoCasas;
        }
    }
}
