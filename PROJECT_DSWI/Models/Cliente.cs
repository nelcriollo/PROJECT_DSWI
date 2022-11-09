using PROJECT_DSWI.DAO.DI;
using System.ComponentModel.DataAnnotations;

namespace PROJECT_DSWI.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        [Display(Name = "Nombre"), Required, StringLength(20)] 
        public string nombre { get; set; }
        [Display(Name = "Apellido"), Required, StringLength(30)] 
        public string apellido { get; set; }
        [Display(Name = "Correo"), Required, StringLength(20)] 
        public string correo { get; set; }
        [Display(Name = "Teléfono"), Required, StringLength(10)] 
        public string telefono { get; set; }
        [Display(Name = "Tipo Documento"), Required] 
        public int idTipoDocumento { get; set; }
        [Display(Name = "Documento"), Required, StringLength(10)] 
        public string documento { get; set; }
        [Display(Name = "Ubigeo"), Required, StringLength(10)] 
        public string cod_ubigeo { get; set; }
        [Display(Name = "Dirección"), Required, StringLength(30)] 
        public string direccion { get; set; }
        public Cliente()
        {
            idCliente = 0;
            nombre = "";
            apellido = "";
            correo = "";
            telefono = "";
            idTipoDocumento = 0;
            documento = "";
            cod_ubigeo = "";
            direccion = "";
        }
    }
}
