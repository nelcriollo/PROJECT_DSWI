namespace PROJECT_DSWI.Models
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public int idTipoPedido { get; set; }
        public DateTime fechaHoraPedido { get; set; }
        public decimal totalPedido { get; set; }
        public int idMetodoPago { get; set; }
        public string cod_Ubigeo { get; set; }
        public string direccionPedido { get; set; }
        public int estado { get; set; }
    }
}
}
