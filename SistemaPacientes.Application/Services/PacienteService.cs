
using SistemaPacientes.Application.DTOs;
using SistemaPacientes.Application.Interfaces.Repositories;
using SistemaPacientes.Application.Interfaces.Services;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PacienteDTO>> ObtenerTodosAsync()
        {
            var pacientes = await _repository.ObtenerTodosAsync();

            return pacientes.Select(p => ConvertirDTO(p)).ToList();
        }

        public async Task<PacienteDTO?> ObtenerPorIdAsync(int id)
        {
            var paciente = await _repository.ObtenerPorIdAsync(id);

            if (paciente == null)
                return null;

            return ConvertirDTO(paciente);
        }

        public async Task<PacienteDTO> CrearAsync(CrearPacienteDTO dto)
        {
            if (await _repository.ExisteCedulaAsync(dto.Cedula))
                throw new InvalidOperationException(
                    "Ya existe un paciente con esta cédula.");

            var paciente = new Paciente
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Cedula = dto.Cedula,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Direccion = dto.Direccion,
                Activo = true
            };

            await _repository.AgregarAsync(paciente);
            await _repository.GuardarCambiosAsync();

            return ConvertirDTO(paciente);
        }

        public async Task<bool> ActualizarAsync(
            int id,
            ActualizarPacienteDTO dto)
        {
            var paciente = await _repository.ObtenerPorIdAsync(id);

            if (paciente == null)
                return false;

            if (await _repository.ExisteCedulaAsync(dto.Cedula, id))
                throw new InvalidOperationException(
                    "La cédula pertenece a otro paciente.");

            paciente.Nombres = dto.Nombres;
            paciente.Apellidos = dto.Apellidos;
            paciente.Cedula = dto.Cedula;
            paciente.FechaNacimiento = dto.FechaNacimiento;
            paciente.Sexo = dto.Sexo;
            paciente.Telefono = dto.Telefono;
            paciente.Email = dto.Email;
            paciente.Direccion = dto.Direccion;
            paciente.Activo = dto.Activo;

            _repository.Actualizar(paciente);
            await _repository.GuardarCambiosAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var paciente = await _repository.ObtenerPorIdAsync(id);

            if (paciente == null)
                return false;

            _repository.Eliminar(paciente);
            await _repository.GuardarCambiosAsync();

            return true;
        }

        private static PacienteDTO ConvertirDTO(Paciente paciente)
        {
            return new PacienteDTO
            {
                Id = paciente.Id,
                Nombres = paciente.Nombres,
                Apellidos = paciente.Apellidos,
                Cedula = paciente.Cedula,
                FechaNacimiento = paciente.FechaNacimiento,
                Sexo = paciente.Sexo,
                Telefono = paciente.Telefono,
                Email = paciente.Email,
                Direccion = paciente.Direccion,
                Activo = paciente.Activo
            };
        }
    }
}
