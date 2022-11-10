using Microsoft.AspNetCore.Mvc;
using PROJECT_DSWI.DAO;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.Controllers
{
    public class UsuarioController : Controller

      
   {
        IUsuario _iusuarios;

        public UsuarioController()
        {
            _iusuarios = new UsuarioDAO();
        }


        public IActionResult ListarUsuarios()
        {

            IEnumerable<Usuario> listUsu = _iusuarios.listarUsuarios();
            return View(listUsu);
        }
    }
}
