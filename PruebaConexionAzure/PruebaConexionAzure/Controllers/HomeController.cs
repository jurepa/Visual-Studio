using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaConexionAzure.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = "Server = tcp:personasdbserver2.database.windows.net, 1433; Initial Catalog = PersonasDB; Persist Security Info = False; User ID = pjarana; Password =Jatabo29; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                if (connection.State.ToString()=="Closed")
                {
                    connection.Open();
                    ViewData["info"] = "Conexión a tope";
                }
            }
            catch (SqlException e)
            {
                ViewData["info"] = "Error conexion sql: " + e;
            }
            return View("Index");
        }
    }
}