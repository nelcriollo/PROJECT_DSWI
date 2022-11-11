using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface ICategoria
    {

        IEnumerable<Categoria> GetCategorias();
        string insertCategoria(Categoria reg);
        string ActualizarCategoria(Categoria reg);


    }
}
