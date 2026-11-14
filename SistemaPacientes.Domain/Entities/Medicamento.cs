
namespace SistemaPacientes.Domain.Entities
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Concentracion { get; set; } = string.Empty;
        public string Presentacion { get; set; } = string.Empty;
        public int Stock { get; set; }

        public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    }
}
