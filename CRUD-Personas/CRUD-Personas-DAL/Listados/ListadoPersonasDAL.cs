using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;
using CRUD_Personas_DAL;
using CRUD_Personas_DAL.Conexion;
using System.Data.SqlClient;

namespace CRUD_Personas_DAL.Listados
{
    public class ListadoPersonasDAL
    {
        public List<Persona> listado { get; set; }

        public ListadoPersonasDAL()
        {
            this.listado = new List<Persona>();
        }
        public List<Persona> getPersonas()
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Persona p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select*From Personas";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new Persona();
                        p.idPersona = (int)lector["ID"];
                        p.nombre = (string)lector["nombre"];
                        p.apellidos = (string)lector["apellidos"];
                        p.direccion = (string)lector["direccion"];
                        p.telefono = (string)lector["telefono"];
                        this.listado.Add(p);
                    }
                }
                cx.closeConnection();
            }
            catch (SqlException )
            {
                throw;
            }

            return this.listado;
        }
        public Persona getPersona(int id)
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Persona p=null;
            SqlCommand consulta = new SqlCommand();
            SqlParameter idParam=new SqlParameter();
            try
            {
                idParam.ParameterName = "@id";
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Value = id;
                consulta.Parameters.Add(idParam);
                consulta.CommandText = "Select*From Personas where id=@id";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                        lector.Read();
                        p = new Persona();
                        p.idPersona = (int)lector["ID"];
                        p.nombre = (string)lector["nombre"];
                        p.apellidos = (string)lector["apellidos"];
                        p.direccion = (string)lector["direccion"];
                        p.telefono = (string)lector["telefono"];

                }
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }

            return p;
        }

        public void updatePersona(Persona p)
        {
            Connection cx = new Connection();
            SqlCommand consulta = new SqlCommand();
            SqlParameter nombre = new SqlParameter() ;
            SqlParameter apellidos = new SqlParameter();
            SqlParameter id = new SqlParameter();
            SqlParameter direccion = new SqlParameter();
            SqlParameter telefono = new SqlParameter();
            try
            {
                nombre.ParameterName = "@nombre";
                nombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombre.Value = p.nombre;

                apellidos.ParameterName = "@apellidos";
                apellidos.SqlDbType = System.Data.SqlDbType.NVarChar;
                apellidos.Value = p.apellidos;

                direccion.ParameterName = "@direccion";
                direccion.SqlDbType = System.Data.SqlDbType.NVarChar;
                direccion.Value = p.direccion;

                telefono.ParameterName = "@telefono";
                telefono.SqlDbType = System.Data.SqlDbType.Char;
                telefono.Value = p.telefono;

                id.ParameterName = "@id";
                id.SqlDbType = System.Data.SqlDbType.Int;
                id.Value = p.idPersona;

                consulta.Parameters.Add(nombre);
                consulta.Parameters.Add(apellidos);
                consulta.Parameters.Add(direccion);
                consulta.Parameters.Add(telefono);
                consulta.Parameters.Add(id);
                consulta.CommandText = "Update Personas" +
                    " set Nombre=@nombre, Apellidos=@apellidos, Direccion=@direccion, Telefono=@telefono WHERE ID=@id";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void deletePersona(int id)
        {
            Connection cx = new Connection();
            SqlCommand consulta = new SqlCommand();

            SqlParameter idParam = new SqlParameter();

            try
            {


                idParam.ParameterName = "@id";
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Value = id;
                consulta.Parameters.Add(idParam);
                consulta.CommandText = "DELETE FROM PERSONAS WHERE ID=@id ";
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
