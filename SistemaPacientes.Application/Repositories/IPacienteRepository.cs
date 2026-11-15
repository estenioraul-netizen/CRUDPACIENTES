
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Application.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObtenerTodosAsync();

        Task<Paciente?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Paciente paciente);

        void Actualizar(Paciente paciente);

        void Eliminar(Paciente paciente);

        Task<bool> ExisteCedulaAsync(string cedula, int? excluirId = null);

        Task GuardarCambiosAsync();
    }
}
