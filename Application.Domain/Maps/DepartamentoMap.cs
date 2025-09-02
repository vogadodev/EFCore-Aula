using Application.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Domain.Maps
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("APP_DEPARTAMENTO_DEP");
            builder.HasKey(x=> x.ID);
            builder.Property(x => x.ID).HasColumnName("DEP_ID").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnName("DEP_NOME");
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(400).HasColumnName("DEP_DESCRICAO");
        }
    }
}
