using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método devuelve el objeto SqlConnection.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace _17_CRUD_Personas_UWP_DAL
{
    public class Connection
    {
        //Atributos
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public SqlConnection conexion{ get;}
        public Uri uri { set; get; }

        //Constructores

        public Connection()
        {
            this.dataBase = "PersonasDB";
            //El primer usuario es de de la base de datos del instituto, el segundo la de casa
            this.user = "pjarana";
            //this.user = "pruebaResident";
            this.pass = "Jatabo29";
            this.conexion = new SqlConnection();
            this.uri =new Uri("http://crud-personas-ui20171127012114.azurewebsites.net/"); //ESTO ES LO Q ESTA MAL, TENDRIA QUE TENER UNA API DE PERSONAS
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";
                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                this.conexion.ConnectionString = string.Format($"server=personasdbserver2.database.windows.net;database={dataBase};uid={user};pwd={pass};");
                this.conexion.Open();
            }
            catch (SqlException)
            {
                throw;
            }

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public Connection(String database, String user, String pass)
        {
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
            this.conexion = new SqlConnection();
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";
                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                this.conexion.ConnectionString = string.Format("server=personasdbserver2.database.windows.net;database={0};uid={1};pwd={2};", dataBase, user, pass);
                this.conexion.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }


        //METODOS

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>The connection is closed.</post>
        /// <param name="connection">La entrada es la conexión a cerrar
        /// </param>
        public void closeConnection()
        {
            try
            {
                this.conexion.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw; 
            }
            catch (Exception)
            {
            throw;
            }
        }


    }

}
