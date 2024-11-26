using System.Text.Json.Serialization;

namespace sistemaGerencia.Models
{
    public class SistemaModel
    {
        public int IdSistema { get; set; }
        public string? NomeSistema { get; set; }
        public string? DescricaoSistema { get; set; }
        [JsonIgnore]
        public ICollection<GrupoModel>? grupos { get; set; }
    }
}
