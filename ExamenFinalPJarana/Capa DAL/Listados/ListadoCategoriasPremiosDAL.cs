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
    public class ListadoCategoriasPremiosDAL
    {
        public List<CategoriasPremios>listadoCategoriasPremios{get;set;}
        public ListadoCategoriasPremiosDAL()
        {
            this.listadoCategoriasPremios = new List<CategoriasPremios>();
        }
        /// <summary>
        /// Devuelve el listado de categorias de premios
        /// </summary>
        /// <returns></returns>
        public List<CategoriasPremios> getListadoCategoriasPremiosDAL()
        {
            SqlDataReader lector;
            CategoriasPremios categoriaPremio ;
            SqlCommand consulta = new SqlCommand();
            Connection cx = new Connection();
            try
            {
                consulta.Connection = cx.conexion;
                consulta.CommandText = "Select*from categoriasPremios";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        categoriaPremio = new CategoriasPremios();
                        categoriaPremio.idCategoriaPremio = (int)lector["idCategoriaPremio"];
                        categoriaPremio.nombreCategoriaPremio = (string)lector["nombreCategoriaPremio"];
                        this.listadoCategoriasPremios.Add(categoriaPremio);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();
            return this.listadoCategoriasPremios;
        }
    }
}
