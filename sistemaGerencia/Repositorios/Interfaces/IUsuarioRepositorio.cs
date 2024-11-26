using sistemaGerencia.Models;

namespace sistemaGerencia.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
        Task<UsuarioModel> BuscarPorCredenciais(string usuario);
        Task<bool> ExcluirUsuario(int id);
        Task<List<PermissaoModel>> BuscarPermissoesPorNome(string nomeUsuario);
    }
}
