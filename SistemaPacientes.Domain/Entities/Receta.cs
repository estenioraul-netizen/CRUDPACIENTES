
namespace SistemaPacientes.Domain.Entities
{
    public class Receta
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public int MedicamentoId { get; set; }
        public string Dosis { get; set; } = string.Empty;
        public string Frecuencia { get; set; } = string.Empty;
        public int DuracionDias { get; set; }
        public DateTime Fecha { get; set; }

        public Consulta Consulta { get; set; } = null!;
        public Medicamento Medicamento { get; set; } = null!;
    }
}
