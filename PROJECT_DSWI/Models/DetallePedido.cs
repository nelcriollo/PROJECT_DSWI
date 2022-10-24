using System.ComponentModel.DataAnnotations;

namespace PROJECT_DSWI.Models
{
    public class DetallePedido
    {
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idPrecio { get; set; }

    }
}
