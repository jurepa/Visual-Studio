using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_DAL.Listados
{
    public class ListadoDepartamentosDAL
    {
        public List<Departamento> listado { get; set; }

        public ListadoDepartamentosDAL()
        {
            this.listado = new List<Departamento>();
        }
        public List<Departamento> getDepartamentos()
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Departamento d;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select*From Departamentos";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        d = new Departamento();
                        d.id = (int)lector["ID"];
                        d.nombre = (string)lector["Nombre"];

                        this.listado.Add(d);
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
    }
}
