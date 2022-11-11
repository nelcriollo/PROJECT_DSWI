namespace PROJECT_DSWI.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public int idTipoDocumento { get; set; }
        public string documento { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string ConfirmarClave { get; set; }
    }
}
