using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface IReserva
    {
        IEnumerable<Reserva> listarReservaCliente(string doc);
        string RegistrarReserva(Reserva reg);

    }
}
