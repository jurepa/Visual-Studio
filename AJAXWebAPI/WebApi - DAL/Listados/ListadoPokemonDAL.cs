using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi___DAL.Conexion;
using WebAPI___ET;

namespace WebApi___DAL.Listados
{
    public class ListadoPokemonDAL
    {
        public List<Pokemon> listado { get; set; }

        public ListadoPokemonDAL()
        {
            this.listado = new List<Pokemon>();
        }
        /// <summary>
        /// Este método se encarga de leer la tabla entera de pokemons de la base de datos
        /// </summary>
        /// <returns>Un List de Pokemon</returns>
        public List<Pokemon> getPokemons()
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Pokemon p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select*From Pokemons";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new Pokemon();
                        p.idPokemon = (int)lector["idPokemon"];
                        p.nombrePokemon = (string)lector["nombrePokemon"];
                        p.numEvoluciones = (Byte)lector["numEvoluciones"];
                        p.generacion = (Byte)lector["Generacion"];
                        p.habilidad1 = (string)lector["Habilidad1"];
                        if (lector["Habilidad2"] == System.DBNull.Value)
                        {
                            p.habilidad2 = "";
                        }
                        else
                        {
                            p.habilidad2 = (string)lector["Habilidad2"];
                        }
                        if (lector["HabilidadOculta"] == System.DBNull.Value)
                        {
                            p.habilidadOculta = "";
                        }
                        else
                        {
                            p.habilidadOculta = (string)lector["HabilidadOculta"];
                        }
                        p.altura = (double)lector["altura"];
                        p.peso = (double)lector["peso"];
                        p.habitat = (string)lector["Hábitat"];
                        this.listado.Add(p);
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
        /// Este método devuelve un pokemon dependiendo el id pasado
        /// </summary>
        /// <param name="id">El id del pokemon</param>
        /// <returns>Un objeto pokemon</returns>
        public Pokemon getPokemon(int id)
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            Pokemon p = null;
            SqlCommand consulta = new SqlCommand();
            SqlParameter idParam = new SqlParameter();
            try
            {
                idParam.ParameterName = "@id";
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Value = id;
                consulta.Parameters.Add(idParam);
                consulta.CommandText = "Select*From Pokemons where idPokemon=@id";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();
                    p = new Pokemon();
                    p.idPokemon = (int)lector["idPokemon"];
                    p.nombrePokemon = (string)lector["nombrePokemon"];
                    p.numEvoluciones = (Byte)lector["numEvoluciones"];
                    p.generacion = (Byte)lector["Generacion"];
                    p.habilidad1 = (string)lector["Habilidad1"];
                    if (lector["Habilidad2"] == System.DBNull.Value)
                    {
                        p.habilidad2 = "";
                    }
                    else
                    {
                        p.habilidad2 = (string)lector["Habilidad2"];
                    }
                    if (lector["HabilidadOculta"] == System.DBNull.Value)
                    {
                        p.habilidadOculta = "";
                    }
                    else
                    {
                        p.habilidadOculta = (string)lector["HabilidadOculta"];
                    }
                    p.altura = (double)lector["altura"];
                    p.peso = (double)lector["peso"];
                    p.habitat = (string)lector["Hábitat"];

                }
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }

            return p;
        }
        /// <summary>
        /// Este método se encarga de actualizar un pokemon de la base de datos
        /// </summary>
        /// <param name="p">Un objeto pokemon</param>
        public void updatePokemon(int id, Pokemon p)
        {
            Connection cx = new Connection();
            SqlCommand consulta = new SqlCommand();
            SqlParameter nombrePokemon = new SqlParameter();
            SqlParameter habitat = new SqlParameter();
            SqlParameter idPokemon = new SqlParameter();
            SqlParameter habilidad1 = new SqlParameter();
            SqlParameter habilidad2 = new SqlParameter();
            SqlParameter habilidadOculta = new SqlParameter();
            SqlParameter peso = new SqlParameter();
            SqlParameter altura = new SqlParameter();
            SqlParameter numEvoluciones = new SqlParameter();
            SqlParameter generacion = new SqlParameter();
            try
            {
                nombrePokemon.ParameterName = "@nombrePokemon";
                nombrePokemon.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombrePokemon.Value = p.nombrePokemon;

                numEvoluciones.ParameterName = "@numEvoluciones";
                numEvoluciones.SqlDbType = System.Data.SqlDbType.TinyInt;
                numEvoluciones.Value = p.numEvoluciones;

                generacion.ParameterName = "@generacion";
                generacion.SqlDbType = System.Data.SqlDbType.TinyInt;
                generacion.Value = p.generacion;

                habitat.ParameterName = "@habitat";
                habitat.SqlDbType = System.Data.SqlDbType.NVarChar;
                habitat.Value = p.habitat;

                habilidad1.ParameterName = "@habilidad1";
                habilidad1.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidad1.Value = p.habilidad1;
                
                habilidad2.ParameterName = "@habilidad2";
                habilidad2.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidad2.Value = p.habilidad2;

                habilidadOculta.ParameterName = "@habilidadOculta";
                habilidadOculta.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidadOculta.Value = p.habilidadOculta;

                peso.ParameterName = "@peso";
                peso.SqlDbType = System.Data.SqlDbType.Float;
                peso.Value = p.peso;

                altura.ParameterName = "@altura";
                altura.SqlDbType = System.Data.SqlDbType.Float;
                altura.Value = p.altura;

                idPokemon.ParameterName = "@idPokemon";
                idPokemon.SqlDbType = System.Data.SqlDbType.Int;
                idPokemon.Value = id;

                consulta.Parameters.Add(nombrePokemon);
                consulta.Parameters.Add(habitat);
                consulta.Parameters.Add(habilidad1);
                consulta.Parameters.Add(habilidad2);
                consulta.Parameters.Add(habilidadOculta);
                consulta.Parameters.Add(peso);
                consulta.Parameters.Add(altura);
                consulta.Parameters.Add(idPokemon);
                consulta.Parameters.Add(numEvoluciones);
                consulta.Parameters.Add(generacion);
                consulta.CommandText = "Update Pokemons" +
                    " set nombrePokemon=@nombrePokemon,numEvoluciones=@numEvoluciones, Generacion=@generacion, Hábitat=@habitat, Habilidad1=@habilidad1, Habilidad2=@habilidad2, HabilidadOculta=@habilidadOculta, Peso=@peso, Altura=@altura WHERE idPokemon=@idPokemon";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        /// <summary>
        /// Este método se encarga de borrar un pokemon de la base de datos
        /// </summary>
        /// <param name="id">El id del pokemon</param>
        public void deletePokemon(int id)
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
                consulta.CommandText = "DELETE FROM Pokemons WHERE idPokemon=@id ";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        /// <summary>
        /// Este método se encarga de insertar un pokemon en la base de datos
        /// </summary>
        /// <param name="p">Un objeto pokemon</param>
        public void insertPokemon(Pokemon p)
        {
            Connection cx = new Connection();
            SqlCommand consulta = new SqlCommand();
            SqlParameter nombrePokemon = new SqlParameter();
            SqlParameter habitat = new SqlParameter();
            SqlParameter habilidad1 = new SqlParameter();
            SqlParameter habilidad2 = new SqlParameter();
            SqlParameter habilidadOculta = new SqlParameter();
            SqlParameter peso = new SqlParameter();
            SqlParameter altura = new SqlParameter();
            SqlParameter numEvoluciones = new SqlParameter();
            SqlParameter generacion = new SqlParameter();
            try
            {
                nombrePokemon.ParameterName = "@nombrePokemon";
                nombrePokemon.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombrePokemon.Value = p.nombrePokemon;

                habitat.ParameterName = "@habitat";
                habitat.SqlDbType = System.Data.SqlDbType.NVarChar;
                habitat.Value = p.habitat;

                habilidad1.ParameterName = "@habilidad1";
                habilidad1.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidad1.Value = p.habilidad1;

                habilidad2.ParameterName = "@habilidad2";
                habilidad2.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidad2.Value = "";

                habilidadOculta.ParameterName = "@habilidadOculta";
                habilidadOculta.SqlDbType = System.Data.SqlDbType.NVarChar;
                habilidadOculta.Value = "";

                peso.ParameterName = "@peso";
                peso.SqlDbType = System.Data.SqlDbType.Float;
                peso.Value = p.peso;

                altura.ParameterName = "@altura";
                altura.SqlDbType = System.Data.SqlDbType.Float;
                altura.Value = p.altura;

                numEvoluciones.ParameterName = "@numEvoluciones";
                numEvoluciones.SqlDbType = System.Data.SqlDbType.TinyInt;
                numEvoluciones.Value = p.numEvoluciones;

                generacion.ParameterName = "@generacion";
                generacion.SqlDbType = System.Data.SqlDbType.TinyInt;
                generacion.Value = p.generacion;

                consulta.Parameters.Add(nombrePokemon);
                consulta.Parameters.Add(habitat);
                consulta.Parameters.Add(habilidad1);
                consulta.Parameters.Add(habilidad2);
                consulta.Parameters.Add(habilidadOculta);
                consulta.Parameters.Add(peso);
                consulta.Parameters.Add(altura);
                consulta.Parameters.Add(numEvoluciones);
                consulta.Parameters.Add(generacion);
                consulta.CommandText = "INSERT INTO Pokemons(nombrePokemon,numEvoluciones,Generacion,Habilidad1,Habilidad2,HabilidadOculta,Peso,Altura,Hábitat) VALUES (@nombrePokemon,@numEvoluciones,@generacion, @habilidad1,@habilidad2,@habilidadOculta,@peso,@altura,@habitat)";
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
