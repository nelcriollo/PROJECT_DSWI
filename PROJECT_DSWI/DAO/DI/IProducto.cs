using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface IProducto
    {
        IEnumerable<Producto> listarTodos();
        string RegistrarProducto(Producto reg);
        string ActualizarProducto(Producto reg);



    }
}
