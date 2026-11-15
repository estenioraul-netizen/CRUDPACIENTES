
using SistemaPacientes.Application.DTOs;

namespace SistemaPacientes.Application.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<List<PacienteDTO>> ObtenerTodosAsync();

        Task<PacienteDTO?> ObtenerPorIdAsync(int id);

        Task<PacienteDTO> CrearAsync(CrearPacienteDTO dto);

        Task<bool> ActualizarAsync(int id, ActualizarPacienteDTO dto);

        Task<bool> EliminarAsync(int id);
    }
}
