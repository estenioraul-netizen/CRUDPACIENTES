
namespace SistemaPacientes.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Exequatur { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; } = null!;

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}
