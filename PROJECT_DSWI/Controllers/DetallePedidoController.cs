using Microsoft.AspNetCore.Mvc;
using PROJECT_DSWI.DAO;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.Controllers
{
    public class DetallePedidoController : Controller
    {
        IDetallePedido _idetallepedido;

        public DetallePedidoController()
        {
            _idetallepedido = new DetallePedidoDAO();
        }
        

        public IActionResult ListarDetallePedido()
        {
            IEnumerable<DetallePedido> listDetallePedido = _idetallepedido.listarDetallePedido ();
            return View();
        }
    }
}
