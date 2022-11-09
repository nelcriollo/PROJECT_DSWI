using PROJECT_DSWI.Models;
namespace PROJECT_DSWI.DAO.DI
{
    public interface ICliente
    {
        IEnumerable<Cliente> listado();
        Cliente buscar(int codigo);
        string agregar(Cliente reg);
        string actualizar(Cliente reg);
        string eliminar(Cliente reg);
    }
}
