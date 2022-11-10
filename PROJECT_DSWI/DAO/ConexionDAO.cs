using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {
<<<<<<< HEAD
        SqlConnection cn = new SqlConnection(@"server = EROJASP;database = SABORCRIOLLO;Trusted_Connection = True;" +
         "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False");
=======
        SqlConnection cn = new SqlConnection(@"server = LAPTOP-BB5T8A26\MSSQLSERVER01;database = SABORCRIOLLO;Trusted_Connection = True;" +
        "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False ");
>>>>>>> d726cf72f626697418dd2ef0329b2d518c7f0021

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
