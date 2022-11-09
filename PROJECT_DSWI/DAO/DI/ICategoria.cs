using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface ICategoria
    {

        IEnumerable<CategoriaDAO> GetCategorias();
        string insertCategoria(Categoria reg);
        string ActualizarCategoria(Categoria reg);


    }
}
