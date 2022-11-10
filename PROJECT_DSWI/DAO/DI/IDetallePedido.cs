using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface IDetallePedido
    {
        IEnumerable<DetallePedido> listarDetallePedido();

        string RegistrarDetallePedido(DetallePedido reg);
        string ActualizarDetallePedido(DetallePedido reg);
        
    }
}
