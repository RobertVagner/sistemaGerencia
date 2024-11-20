using sistemaGerencia.Models;

namespace sistemaGerencia.Repositorios.Interfaces
{
    public interface IPermissaoRepositorio
    {
        Task<List<PermissaoModel>> BuscarTodosPermissao();
        Task<PermissaoModel> BuscarPorId(int id);
        Task<PermissaoModel> AdicionarPermissao(PermissaoModel permissao);
        Task<PermissaoModel> AtualizarPermissao(PermissaoModel permissao, int id);
        Task<bool> ExcluirPermissao(int id);
    }
}
