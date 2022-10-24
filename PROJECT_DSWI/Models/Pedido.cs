using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace PROJECT_DSWI.Models
{
    public class Pedido
    {
        public int idPedido { get; set; }
        [Display(Name = "Cliente"), Required] public int idCliente { get; set; }
        [Display(Name = "Tipo Pedido"), Required] public int idTipoPedido { get; set; }
        [Display(Name = "Fecha"),Required]public DateTime fechaHoraPedido { get; set; }
        [Display(Name = "Total"), Required] public decimal totalPedido { get; set; }
        [Display(Name = "Método"), Required] public int idMetodoPago { get; set; }
        [Display(Name = "Ubigeo"), Required,StringLength(10)] public string cod_Ubigeo { get; set; }
        [Display(Name = "Dirección"), Required, StringLength(30)] public string direccionPedido { get; set; }
        [Display(Name = "Estado"), Required, StringLength(10)] public int estado { get; set; }
        public Pedido()
        {
            idPedido = 0;
            idCliente = 0;
            idTipoPedido = 0;
            fechaHoraPedido = DateTime.Now;
            totalPedido = 0;
            idMetodoPago = 0;
            cod_Ubigeo = "";
            direccionPedido = "";
            estado = 0;
        }
    }
}
