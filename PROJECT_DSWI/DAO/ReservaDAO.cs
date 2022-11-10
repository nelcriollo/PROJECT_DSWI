using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ReservaDAO : IReserva
    {
        public IEnumerable<Reserva> listarReservaCliente(string doc)
        {
            throw new NotImplementedException();
        }

        public string RegistrarReserva(Reserva reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn) 
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmc = new SqlCommand();
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}
