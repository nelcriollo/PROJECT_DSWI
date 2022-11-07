using Microsoft.AspNetCore.Mvc;
using PROJECT_DSWI.DAO;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.Controllers
{
    public class ProductoController : Controller
    {
        IProducto _iaproducto;
        public ProductoController()
        {
            _iaproducto = new ProductoDAO();
        }
        public IActionResult ListarProductos()
        {
           IEnumerable<Producto> lists =  _iaproducto.listarTodos();

            return View(lists);
        }
    }
}
