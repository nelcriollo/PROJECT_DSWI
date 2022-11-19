using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ReservaDAO : ConexionDAO, IReserva
    {
        public IEnumerable<Reserva> listarReservaCliente(string doc)
        {
            throw new NotImplementedException();
        }

        public string RegistrarReserva(Reserva reg)
        {
            string mensaje = "";
            return mensaje;
        }
    }
}
