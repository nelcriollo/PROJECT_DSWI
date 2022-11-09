using PROJECT_DSWI.Models;
namespace PROJECT_DSWI.DAO.DI
{
    public interface IPedido
    {
        IEnumerable<Pedido> listado();
        Pedido buscar(int codigo);
        string agregar(Pedido reg);
        string actualizar(Pedido reg);
        string eliminar(Pedido reg);
    }
}
