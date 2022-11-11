using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {
<<<<<<< HEAD


=======
>>>>>>> 6cb4a34ce2d1276b9a71dd920318276495af59a1

        SqlConnection cn = new SqlConnection(@"server = LAPTOP-BB5T8A26\MSSQLSERVER01;database = SABORCRIOLLO;Trusted_Connection = True;" +
        "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False ");

<<<<<<< HEAD



=======
        /*SqlConnection cn = new SqlConnection(@"server = EROJASP;database = SABORCRIOLLO;Trusted_Connection = True;" +
         "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False");
        >>>>>>> 06b005b749a44a2c8b8fe75645b858ad8cb09879

        SqlConnection cn = new SqlConnection(@"server = ASOTON;database = SABORCRIOLLO;Trusted_Connection = True;" +
         "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False");
        >>>>>>> 06b005b749a44a2c8b8fe75645b858ad8cb09879*/
>>>>>>> 6cb4a34ce2d1276b9a71dd920318276495af59a1

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
