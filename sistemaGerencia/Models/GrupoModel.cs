namespace sistemaGerencia.Models
{
    public class GrupoModel
    {
        public int IdGrupo { get; set; }
        public string? NomeGrupo { get; set; }
        public string? DescricaoGrupo { get; set; }
        public ICollection<UsuarioModel>? usuarios { get; set; }
        public ICollection<PermissaoModel>? permissoes { get; set; }
        public ICollection<SistemaModel>? sistemas { get; set; }

    }
}
