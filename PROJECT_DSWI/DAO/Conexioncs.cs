using Microsoft.Data.SqlClient;

namespace PROJECT_DSWI.DAO
{
    public class Conexioncs
    {
        SqlConnection cn = new SqlConnection(@"server=NELSON\MSSQLSERVER2;DataBase= BD_SaborCriollo_v1.0.2;" +
      "Trusted_Connection = False; uid = sa; pwd = 123456; MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False;");

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
