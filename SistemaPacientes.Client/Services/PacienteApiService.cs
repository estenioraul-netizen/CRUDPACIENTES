
using System.Net.Http.Json;
using SistemaPacientes.Client.Models;

namespace SistemaPacientes.Client.Services
{
    public class PacienteApiService
    {
        private readonly HttpClient _http;

        public PacienteApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Paciente>> ObtenerTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<Paciente>>("api/Pacientes")
                   ?? new List<Paciente>();
        }

        public async Task CrearAsync(Paciente paciente)
        {
            var respuesta = await _http.PostAsJsonAsync("api/Pacientes", paciente);
            respuesta.EnsureSuccessStatusCode();
        }

        public async Task ActualizarAsync(int id, Paciente paciente)
        {
            var respuesta = await _http.PutAsJsonAsync($"api/Pacientes/{id}", paciente);
            respuesta.EnsureSuccessStatusCode();
        }

        public async Task EliminarAsync(int id)
        {
            var respuesta = await _http.DeleteAsync($"api/Pacientes/{id}");
            respuesta.EnsureSuccessStatusCode();
        }
    }
}
