using sistemaGerencia.Models;

namespace sistemaGerencia.Repositorios.Interfaces
{
    public interface IGrupoRepositorio
    {
        Task<List<GrupoModel>> BuscarTodosGrupos();
        Task<GrupoModel> BuscarPorId(int id);
        Task<GrupoModel> AdicionarGrupo(GrupoModel grupo);
        Task<GrupoModel> AtualizarGrupo(GrupoModel grupo, int id);
        Task<bool> ExcluirGrupo(int id);
    }
}
