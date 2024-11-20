using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaGerencia.Models;

namespace sistemaGerencia.Data.Map
{
    public class GrupoMap : IEntityTypeConfiguration<GrupoModel>
    {
        public void Configure(EntityTypeBuilder<GrupoModel> builder)
        {
            builder.HasKey(x => x.IdGrupo);
            builder.Property(x => x.NomeGrupo).IsRequired().HasMaxLength(125);
            builder.Property(x => x.DescricaoGrupo).IsRequired().HasMaxLength(500);
        }
    }
}
