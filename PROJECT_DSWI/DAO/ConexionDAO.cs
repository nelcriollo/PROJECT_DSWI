using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {
        private readonly IConfigurationRoot _config;



        public ConexionDAO()
        {
            _config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public SqlConnection getConexion()
        {
            SqlConnection con = new SqlConnection();
            string cadena = "";
            cadena = _config.GetConnectionString("conexion");
            con.ConnectionString = (cadena);
            return con;
        }
    }
}
