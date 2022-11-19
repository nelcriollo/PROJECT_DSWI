using Microsoft.Data.SqlClient;
namespace PROJECT_DSWI.DAO
{
    public class ConexionDAO
    {
<<<<<<< HEAD
=======

>>>>>>> 9380a1b (asdasd)


        SqlConnection cn = new SqlConnection(@"server = LAPTOP-BB5T8A26\MSSQLSERVER01;database = SABORCRIOLLO;Trusted_Connection = True;" +
        "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False ");

<<<<<<< HEAD
        /*SqlConnection cn = new SqlConnection(@"server = EROJASP;database = SABORCRIOLLO;Trusted_Connection = True;" +
         "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False");
        >>>>>>> 06b005b749a44a2c8b8fe75645b858ad8cb09879

        SqlConnection cn = new SqlConnection(@"server = ASOTON;database = SABORCRIOLLO;Trusted_Connection = True;" +
         "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False");
        >>>>>>> 06b005b749a44a2c8b8fe75645b858ad8cb09879*/
=======
>>>>>>> 9380a1b (asdasd)

        // lectura de la conexion
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
