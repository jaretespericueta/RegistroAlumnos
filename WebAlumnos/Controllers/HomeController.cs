using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using WebAlumnos.Models;

namespace WebAlumnos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registro(string nombre, string paterno, string materno, int edad)
        {
            /*Pasos para conectarse a una base de datos
             * 1. crear la cadena de conexion 
             * 2. crear un objeto para conectar a la bd (SqlConecction)
             * 3. conectarse a la bd o abrir la conexion
             * 4. crear el query que se va a ejecutar
             * 5. crear un objeto para ejecutar el query (SqlCommand)
             * 6. ejecutar el query
             * 7. cerrar la conexion
             */
            string cadenaConexion = "server=MSI\\SQLEXPRESS; database=Generacion45; user=sa; password=1223334444; TrustServerCertificate=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            string query = $"INSERT INTO Alumnos (nombre, paterno, materno, edad) VALUES ('{nombre}', '{paterno}', '{materno}', {edad});";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            TempData["mensaje"] = "Alumno registrado correctamente";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
