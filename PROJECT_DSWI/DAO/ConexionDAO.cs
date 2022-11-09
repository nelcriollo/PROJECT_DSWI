using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {
        SqlConnection cn = new SqlConnection(@"server=NELSON\MSSQLSERVER2;DataBase=SABORCRIOLLO;Trusted_Connection = False; uid = sa; pwd = 123; MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False;");

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
