namespace PROJECT_DSWI.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int idTipoDocumento { get; set; }
        public string documento { get; set; }
        public string cod_ubigeo { get; set; }
        public string direccion { get; set; }
    }
}
