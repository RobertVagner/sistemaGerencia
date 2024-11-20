using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _dbContext;
        public UsuarioRepositorio(SistemaGerenciamentoDBContext sistemaGerenciamentoDBContext)
        {
            _dbContext = sistemaGerenciamentoDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.usuario.FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.usuario.ToListAsync();
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado!");
            }

            userPorId.NomeUsuario = usuario.NomeUsuario;
            userPorId.EmailUsuario = usuario.EmailUsuario;

            _dbContext.usuario.Update(userPorId);
            await _dbContext.SaveChangesAsync();

            return userPorId;
        }

        public async Task<bool> ExcluirUsuario(int id)
        {
            UsuarioModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado!");
            }

            _dbContext.usuario.Remove(userPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
