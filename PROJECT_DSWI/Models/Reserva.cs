using System.ComponentModel.DataAnnotations;

namespace PROJECT_DSWI.Models
{
    public class Reserva
    {
        public int idReserva { get; set; }
        public int idLocal { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public DateTime fechaReserva { get; set; }
        public DateTime horaReserva { get; set; }
        public int cantidadPersonas { get; set; }
        public string observacion { get; set; }
        public int estado { get; set; }

    }
}
