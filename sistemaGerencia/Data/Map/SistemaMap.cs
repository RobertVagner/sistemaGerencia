using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaGerencia.Models;

namespace sistemaGerencia.Data.Map
{
    public class SistemaMap : IEntityTypeConfiguration<SistemaModel>
    {
        public void Configure(EntityTypeBuilder<SistemaModel> builder)
        {
            builder.HasKey(x => x.IdSistema);
            builder.Property(x => x.NomeSistema).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DescricaoSistema).IsRequired().HasMaxLength(1000);
        }
    }
}
