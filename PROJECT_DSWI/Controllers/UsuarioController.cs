using Microsoft.AspNetCore.Mvc;
using PROJECT_DSWI.DAO;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
