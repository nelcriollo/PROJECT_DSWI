using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {



        SqlConnection cn = new SqlConnection(@"server = LAPTOP-BB5T8A26\MSSQLSERVER01;database = SABORCRIOLLO;Trusted_Connection = True;" +
        "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False ");

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
