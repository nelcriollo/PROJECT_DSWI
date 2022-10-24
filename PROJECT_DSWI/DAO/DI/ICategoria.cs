using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface ICategoria
    {
        IEnumerable<CategoriaDAO> GetCategorias();
        string insertCategoria();
        string ActualizarCategoria();

    }
}
