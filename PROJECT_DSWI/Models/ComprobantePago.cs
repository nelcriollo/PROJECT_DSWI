namespace PROJECT_DSWI.Models
{
    public class ComprobantePago
    {
        public string TipoComprobante { get; set; }
        public int NumComprobante { get; set; }
        public int idPedido { get; set; }
        public int idTipoPedido { get; set; }
        public decimal subtotal { get; set; }
        public decimal igv { get; set; }
        public decimal ImporteTotal { get; set; }

    }
}
