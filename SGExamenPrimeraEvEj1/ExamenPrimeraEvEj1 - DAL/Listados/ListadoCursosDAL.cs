using ExamenPrimeraEvEj1___DAL.Conexion;
using ExamenPrimeraEvEj1___ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvEj1___DAL.Listados
{
    public class ListadoCursosDAL
    {
        public List<Curso> listado { get; set; }

        public ListadoCursosDAL()
        {
            this.listado = new List<Curso>();
        }
        /// <summary>
        /// Método que te devuelve un list con todos los cursos
        /// </summary>
        /// <returns></returns>
        public List<Curso> getCursos()
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Curso c;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select*From Cursos";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        c = new Curso();
                        c.idCurso = (int)lector["idCurso"];
                        c.nombreCurso = (string)lector["nombreCurso"];
                        this.listado.Add(c);
                    }
                }
                cx.closeConnection();
                return this.listado;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
