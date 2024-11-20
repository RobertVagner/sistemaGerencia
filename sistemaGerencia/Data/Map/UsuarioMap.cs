using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaGerencia.Models;

namespace sistemaGerencia.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.IdUsuario);
            builder.Property(x => x.NomeUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EmailUsuario).IsRequired().HasMaxLength(150);
        }
    }
}
