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
    public class ListadoAlumnosDAL
    {
        public List<Alumno> listado { get; set; }

        public ListadoAlumnosDAL()
        {
            this.listado = new List<Alumno>();
        }
        /// <summary>
        /// Método que te devuelve un list de alumnos dependiendo de su id de curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<Alumno> getListadoAlumnosCurso(int idCurso)
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Alumno a = null;
            SqlCommand consulta = new SqlCommand();
            SqlParameter idParam = new SqlParameter();
            try
            {
                idParam.ParameterName = "@idCurso";
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Value = idCurso;
                consulta.Parameters.Add(idParam);
                consulta.CommandText = "Select*From Alumnos where idCurso=@idCurso";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        a = new Alumno();
                        a.nombreAlumno = (string)lector["nombreAlumno"];
                        a.apellidoAlumno = (string)lector["apellidosAlumno"];
                        a.idAlumno = (int)lector["idAlumno"];
                        a.idCurso = (int)lector["idCurso"];
                        if (lector["beca"] != System.DBNull.Value) //Valor nulo de base de datos
                        {
                            //a.beca = Convert.ToDecimal(lector["beca"]);
                            a.beca = (Decimal)lector["beca"];
                        }
                        else
                        {
                            a.beca = 0;
                        }
                        //{
                        //    a.beca = lector.GetDecimal(4);

                        //
                        //}
                        //else
                        //{
                        //    a.beca = 0;
                        //}
                        ////a.beca = (System.Decimal)lector["beca"];
                        this.listado.Add(a);
                    }
                }
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }

            return this.listado;
        }

        /// <summary>
        /// Método que te devuelve un alumno dependiendod e su id
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        /// 
        public Alumno getAlumno(int idAlumno)
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Alumno a = null;
            SqlCommand consulta = new SqlCommand();
            SqlParameter idParam = new SqlParameter();
            try
            {
                idParam.ParameterName = "@id";
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Value = idAlumno;
                consulta.Parameters.Add(idParam);
                consulta.CommandText = "Select*From Alumnos where idAlumno=@id";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();
                    a = new Alumno();
                    a.nombreAlumno = (string)lector["nombreAlumno"];
                    a.apellidoAlumno = (string)lector["apellidosAlumno"];
                    a.idAlumno = (int)lector["idAlumno"];
                    a.idCurso = (int)lector["idCurso"];
                    if (lector["beca"] != System.DBNull.Value) //Valor nulo de base de datos
                    {
                        a.beca = (Decimal)lector["beca"];
                    }
                    else
                    {
                        a.beca = 0;
                    }

                }
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }

            return a;
        }
        /// <summary>
        /// Método que recibe un objeto alumno y lo actualiza en la base de datos
        /// </summary>
        /// <param name="Objeto alumno"></param>
        /// <returns></returns>
        public void updateBecaAlumno(Alumno a)
        {
            Connection cx = new Connection();
            SqlCommand consulta = new SqlCommand();
            SqlParameter beca = new SqlParameter();
            SqlParameter idAlumno = new SqlParameter();

            try
            {

                beca.ParameterName = "@beca";
                beca.SqlDbType = System.Data.SqlDbType.Money;
                beca.Value = a.beca;

                idAlumno.ParameterName = "@idAlumno";
                idAlumno.SqlDbType = System.Data.SqlDbType.Int;
                idAlumno.Value = a.idAlumno;

                consulta.Parameters.Add(beca);
                consulta.Parameters.Add(idAlumno);
                consulta.CommandText = "Update Alumnos" +
                    " set Beca=@beca WHERE idAlumno=@idAlumno";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
