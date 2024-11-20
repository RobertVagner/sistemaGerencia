namespace sistemaGerencia.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? EmailUsuario { get; set; }

        public ICollection<GrupoModel>? grupos { get; set; }
    }
}
