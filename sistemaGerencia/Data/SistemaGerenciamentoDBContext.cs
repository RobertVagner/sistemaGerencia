using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data.Map;
using sistemaGerencia.Models;

namespace sistemaGerencia.Data
{
    public class SistemaGerenciamentoDBContext : DbContext
    {
        public SistemaGerenciamentoDBContext(DbContextOptions<SistemaGerenciamentoDBContext> options)
            :base(options) 
        {
        }

        public DbSet<UsuarioModel> usuario { get; set; }
        public DbSet<GrupoModel> grupo { get; set; }
        public DbSet<PermissaoModel> permissao { get; set; }
        public DbSet<SistemaModel> sistema { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SistemaMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
