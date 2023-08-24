using BackEndApi.Models;
using BackEndApi.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private DbempleadoContext _dbContext;

        public EmpleadoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Empleado>> Lista()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();
                lista = await _dbContext.Empleados.Include(dpt => dpt.IdDepartamentoNavigation).ToListAsync();
                return lista;
            }
            catch { throw; }
        }

        public async Task<Empleado> Obtener(int idEmpleado)
        {
            try
            {
                Empleado? encontrado = new Empleado();

                encontrado = await _dbContext.Empleados.Include(dpt => dpt.IdDepartamentoNavigation)
                    .Where(e => e.IdEmpleado == idEmpleado).FirstOrDefaultAsync();

                return encontrado;
            }
            catch { throw; }
        }

        public async Task<Empleado> Agregar(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch { throw; }
        }

        public async Task<bool> Editar(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<bool> Eliminar(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }
    }
}
