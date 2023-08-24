using BackEndApi.Models;
using BackEndApi.Services.Contrato;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Services.Implementacion
{
    public class DepartamentoService : IDepartamentoService
    {
        private DbempleadoContext _dbContext;

        public DepartamentoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Departamento>> Lista()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();
                lista = await _dbContext.Departamentos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y maneja el caso de conexión fallida
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                throw;
            }
        }
    }
}
