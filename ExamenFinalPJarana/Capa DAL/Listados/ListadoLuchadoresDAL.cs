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
    public class ListadoLuchadoresDAL
    {
        public List<Luchador> listadoLuchadores { get; set; }
        public ListadoLuchadoresDAL()
        {
            this.listadoLuchadores = new List<Luchador>();
        }
        /// <summary>
        /// Devuelve un listado de luchadores
        /// </summary>
        /// <returns></returns>
        public List<Luchador> getListadoLuchadoresDAL()
        {
            SqlDataReader lector;
            Luchador luchador;
            SqlCommand consulta = new SqlCommand();
            Connection cx = new Connection();
            try
            {
                consulta.Connection = cx.conexion;
                consulta.CommandText = "Select*from luchadores";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        luchador = new Luchador();
                        luchador.idLuchador = (int)lector["idLuchador"];
                        luchador.idCasa = (int)lector["idCasa"];
                        luchador.nombreLuchador = (string)lector["nombreLuchador"];
                        this.listadoLuchadores.Add(luchador);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();

            return this.listadoLuchadores;
        }
    }
}
