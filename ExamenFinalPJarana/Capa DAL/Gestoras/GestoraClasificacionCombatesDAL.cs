using Capa_DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraClasificacionCombatesDAL
    {
        /// <summary>
        /// Inserta un objeto ClasificacionCombate en la bbdd
        /// </summary>
        /// <param name="resultadoCombate"></param>
        public void insertClasificacionCombate(ClasificacionCombate resultadoCombate)
        {
            Connection cx = new Connection();
            SqlParameter idLuchadorParameter = new SqlParameter();
            SqlParameter puntosParameter = new SqlParameter();
            SqlParameter idCategoriaParameter = new SqlParameter();
            SqlParameter idCombateParameter = new SqlParameter();
            SqlCommand insert = new SqlCommand();
            try
            {
                idLuchadorParameter.ParameterName = "@idLuchador";
                idLuchadorParameter.SqlDbType = System.Data.SqlDbType.Int;
                idLuchadorParameter.Value = resultadoCombate.idLuchador;

                idCategoriaParameter.ParameterName = "@idCategoriaPremio";
                idCategoriaParameter.SqlDbType = System.Data.SqlDbType.Int;
                idCategoriaParameter.Value = resultadoCombate.idCategoriaPremio;

                puntosParameter.ParameterName = "@puntos";
                puntosParameter.SqlDbType = System.Data.SqlDbType.Int;
                puntosParameter.Value = resultadoCombate.puntos;

                idCombateParameter.ParameterName = "@idCombate";
                idCombateParameter.SqlDbType = System.Data.SqlDbType.Int;
                idCombateParameter.Value = resultadoCombate.idCombate;

                insert.Connection = cx.conexion;
                insert.Parameters.Add(idLuchadorParameter);
                insert.Parameters.Add(puntosParameter);
                insert.Parameters.Add(idCategoriaParameter);
                insert.Parameters.Add(idCombateParameter);
                insert.CommandText = "Insert into clasificacionComabate(idCombate,puntos,idCategoriaPremio,idLuchador) VALUES (@idCombate,@puntos,@idCategoriaPremio,@idLuchador)";
                insert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
