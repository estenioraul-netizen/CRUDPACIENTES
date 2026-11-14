
namespace SistemaPacientes.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
        public ICollection<Hospitalizacion> Hospitalizaciones { get; set; } = new List<Hospitalizacion>();
    }
}
