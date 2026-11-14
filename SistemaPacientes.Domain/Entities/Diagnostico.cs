
namespace SistemaPacientes.Domain.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public Consulta Consulta { get; set; } = null!;
    }
}
