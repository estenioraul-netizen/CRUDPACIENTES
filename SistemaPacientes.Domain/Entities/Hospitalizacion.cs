
namespace SistemaPacientes.Domain.Entities
{
    public class Hospitalizacion
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activa";

        public Paciente Paciente { get; set; } = null!;
        public Habitacion Habitacion { get; set; } = null!;
    }
}
