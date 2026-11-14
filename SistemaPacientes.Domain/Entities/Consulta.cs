
namespace SistemaPacientes.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;

        public Paciente Paciente { get; set; } = null!;
        public Medico Medico { get; set; } = null!;

        public ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();
        public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    }
}
