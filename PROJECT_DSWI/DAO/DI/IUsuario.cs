using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface IUsuario
    {

        IEnumerable<Usuario> listarUsuarios();
        string RegistrarUsuario(Usuario reg);
        string ActualizarUsuario(Usuario reg);
    }
}
