using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaGerencia.Models;

namespace sistemaGerencia.Data.Map
{
    public class PermissaoMap : IEntityTypeConfiguration<PermissaoModel>
    {
        public void Configure(EntityTypeBuilder<PermissaoModel> builder)
        {
            builder.HasKey(x => x.IdPermissao);
            builder.Property(x => x.NomePermissão).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DescricaoPermissao).IsRequired().HasMaxLength(1000);
        }
    }
}
