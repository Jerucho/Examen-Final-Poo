using System.Data.SqlClient;

namespace Pregunta1.Data
{
    public class DBConnection
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnectionStringBuilder generadorCadenaCnx = new SqlConnectionStringBuilder
            {
                DataSource = "JereMessi\\SQLEXPRESS",
                InitialCatalog = "BD_Market",
                UserID = "sa",
                Password = "sql"
            };



            SqlConnection conexion = new SqlConnection(generadorCadenaCnx.ConnectionString);

            return conexion;
        }
    }
}