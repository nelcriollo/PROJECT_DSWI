namespace PROJECT_DSWI.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int idTipoDocumento { get; set; }
        public string documento { get; set; }
        public int idCargo { get; set; }
        public string cod_Ubigeo { get; set; }
        public string direccion { get; set; }
        public int idLocal { get; set; }
    }
}
