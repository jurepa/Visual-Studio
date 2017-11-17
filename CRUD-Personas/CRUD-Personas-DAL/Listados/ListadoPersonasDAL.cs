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
    }
}
