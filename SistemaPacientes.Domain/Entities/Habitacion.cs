
namespace SistemaPacientes.Domain.Entities
{
    public class Habitacion
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Disponible";

        public ICollection<Hospitalizacion> Hospitalizaciones { get; set; } = new List<Hospitalizacion>();
    }
}
