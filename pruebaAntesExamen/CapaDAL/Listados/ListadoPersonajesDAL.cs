using CapaDAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Listados
{
    public class ListadoPersonajesDAL
    {
        public List<Personaje> personajes { get; set; }
        public ListadoPersonajesDAL()
        {
            personajes = new List<Personaje>();
        }
        public List<Personaje> getPersonajesDAL()
        {

            Connection cx = new Connection();
            SqlDataReader lector;
            Personaje p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.Connection = cx.conexion;
                consulta.CommandText = "Select*from Personajes";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new Personaje();
                        p.idPersonaje = (int)lector["idPersonaje"];
                        p.nombre = (string)lector["nombre"];
                        p.alias = (string)lector["alias"];
                        p.armadura = (double)lector["armadura"];
                        p.danno = (double)lector["danno"];
                        p.regeneracion = (double)lector["regeneracion"];
                        p.resistencia = (double)lector["resistencia"];
                        p.vida = (double)lector["vida"];
                        p.velAtaque = (double)lector["velAtaque"];
                        p.velMovimiento = (double)lector["velMovimiento"];
                        this.personajes.Add(p);

                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();
            return personajes;
        }

        public Personaje getPersonajeDAL(int idPersonaje)
        {
            Personaje p = new Personaje();
            SqlDataReader lector;
            Connection cx = new Connection();
            SqlParameter idParameter = new SqlParameter();
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.Connection = cx.conexion;
                idParameter.ParameterName = "@id";
                idParameter.Value = idPersonaje;
                idParameter.SqlDbType = System.Data.SqlDbType.Int;
                consulta.Parameters.Add(idParameter);
                consulta.CommandText = "Select*from Personajes where idPersonaje=@id";
                lector = consulta.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();

                    p = new Personaje();
                    p.idPersonaje = (int)lector["idPersonaje"];
                    p.nombre = (string)lector["nombre"];
                    p.alias = (string)lector["alias"];
                    p.armadura = (double)lector["armadura"];
                    p.danno = (double)lector["danno"];
                    p.regeneracion = (double)lector["regeneracion"];
                    p.resistencia = (double)lector["resistencia"];
                    p.vida = (double)lector["vida"];
                    p.velAtaque = (double)lector["velAtaque"];
                    p.velMovimiento = (double)lector["velMovimiento"];

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            cx.closeConnection();
            return p;
        }
    }
}
