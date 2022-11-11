using PROJECT_DSWI.Models;
namespace PROJECT_DSWI.DAO.DI
{
    public interface ICliente
    {
        IEnumerable<Cliente> listadoCliente();
       // Cliente BuscarCliente(int codigo);
        string RegistrarCliente(Cliente reg);
        string ActualizarCliente(Cliente reg);
        string EliminarCliente(Cliente reg);
    }
}
