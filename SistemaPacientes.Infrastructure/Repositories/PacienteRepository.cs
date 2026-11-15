
using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Application.Interfaces.Repositories;
using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Infrastructure.Context;

namespace SistemaPacientes.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObtenerTodosAsync()
        {
            return await _context.Pacientes
                .AsNoTracking()
                .OrderBy(p => p.Apellidos)
                .ToListAsync();
        }

        public async Task<Paciente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Pacientes
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AgregarAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
        }

        public void Actualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
        }

        public void Eliminar(Paciente paciente)
        {
            _context.Pacientes.Remove(paciente);
        }

        public async Task<bool> ExisteCedulaAsync(
            string cedula,
            int? excluirId = null)
        {
            return await _context.Pacientes.AnyAsync(p =>
                p.Cedula == cedula &&
                (!excluirId.HasValue || p.Id != excluirId.Value));
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
