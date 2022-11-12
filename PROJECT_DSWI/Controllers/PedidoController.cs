using Microsoft.AspNetCore.Mvc;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.DAO;
using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.Controllers
{
    public class PedidoController : Controller
    {
        IPedido _iapedido;
        public PedidoController()
        {
            _iapedido = new PedidoDAO();
        }
        public IActionResult ListarPedidos()
        {
            IEnumerable<Pedido> lists = _iapedido.listado();

            return View(lists);
        }
    }
}
