using PROJECT_DSWI.Models;

namespace PROJECT_DSWI.DAO.DI
{
    public interface IEmpleado
    {
        IEnumerable<Empleado> listarEmpleado();

        string RegistrarEmpleado(Empleado reg);
        string ActualizarEmpleado(Empleado reg);
    }
}
