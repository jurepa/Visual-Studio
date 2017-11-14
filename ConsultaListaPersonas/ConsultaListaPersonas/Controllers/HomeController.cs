using ConsultaListaPersonas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaListaPersonas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Persona> lista = new List<Persona>();
            SqlConnection cx = new SqlConnection();
            SqlDataReader lector;
            Persona p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                cx.ConnectionString = "Server = tcp:personasdbserver2.database.windows.net, 1433; Initial Catalog = PersonasDB; Persist Security Info = False; User ID = pjarana; Password =Jatabo29; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                cx.Open();
                consulta.CommandText="Select*From Personas";
                consulta.Connection = cx;
                lector = consulta.ExecuteReader();

                if(lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new Persona();
                        p.idPersona = (int)lector["ID"];
                        p.nombre = (string)lector["nombre"];
                        p.apellidos = (string)lector["apellidos"];
                        p.direccion = (string)lector["direccion"];
                        p.telefono = (string)lector["telefono"];
                        lista.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
                ViewData["excepcion"] = "Error: " + e;
            }
            return View(lista);
        }
    }
}