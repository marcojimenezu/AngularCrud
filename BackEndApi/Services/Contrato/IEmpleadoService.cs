

using BackEndApi.Models;

namespace BackEndApi.Services.Contrato
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> Lista();
        Task<Empleado> Obtener(int idEmpleado);
        Task<Empleado> Agregar(Empleado modelo);
        Task<bool> Editar(Empleado modelo);
        Task<bool> Eliminar(Empleado modelo);
    }
}
