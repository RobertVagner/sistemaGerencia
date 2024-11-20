using sistemaGerencia.Controllers;
using sistemaGerencia.Models;

namespace sistemaGerencia.Repositorios.Interfaces
{
    public interface ISistemaRepositorio
    {
        Task<List<SistemaModel>> BuscarTodosSistemas();
        Task<SistemaModel> BuscarPorId(int id);
        Task<SistemaModel> AdicionarSistemas(SistemaModel sistemas);
        Task<SistemaModel> AtualizarSistemas(SistemaModel sistemas, int id);
        Task<bool> ExcluirSistemas(int id);
    }
}
