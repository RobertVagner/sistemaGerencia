using System.Text.Json.Serialization;

namespace sistemaGerencia.Models
{
    public class GrupoModel
    {
        public int IdGrupo { get; set; }
        public string? NomeGrupo { get; set; }
        public string? DescricaoGrupo { get; set; }
        [JsonIgnore]
        public ICollection<UsuarioModel>? usuarios { get; set; }
        [JsonIgnore]
        public ICollection<PermissaoModel>? permissoes { get; set; }
        [JsonIgnore]
        public ICollection<SistemaModel>? sistemas { get; set; }

    }
}
