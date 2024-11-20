namespace sistemaGerencia.Models
{
    public class SistemaModel
    {
        public int IdSistema { get; set; }
        public string? NomeSistema { get; set; }
        public string? DescricaoSistema { get; set; }
        public ICollection<GrupoModel> grupos { get; set; }
    }
}
