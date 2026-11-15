using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.DTOs;
using SistemaPacientes.Application.Interfaces.Services;

namespace SistemaPacientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteDTO>>> ObtenerTodos()
        {
            return Ok(await _service.ObtenerTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDTO>> ObtenerPorId(int id)
        {
            var paciente = await _service.ObtenerPorIdAsync(id);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> Crear(CrearPacienteDTO dto)
        {
            try
            {
                var paciente = await _service.CrearAsync(dto);
                return Ok(paciente);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarPacienteDTO dto)
        {
            try
            {
                var resultado = await _service.ActualizarAsync(id, dto);

                if (!resultado)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _service.EliminarAsync(id);

            if (!resultado)
                return NotFound();

            return NoContent();
        }
    }
}