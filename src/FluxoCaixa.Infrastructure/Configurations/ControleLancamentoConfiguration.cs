using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFluxoCaixa.Infrastructure.Configurations;

public class ControleLancamentoConfiguration : IEntityTypeConfiguration<ControleLancamento>
{
    public void Configure(EntityTypeBuilder<ControleLancamento> builder)
    {
        builder
            .ToTable("TB_CONTROLE_LANCAMENTO");

        builder
            .Property(controleLancamento => controleLancamento.Id)
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd();

        builder
            .HasKey(controleLancamento => controleLancamento.Id);

        builder
            .Property(controleLancamento => controleLancamento.DataLancamento)
            .HasColumnType("datetime")
            .HasColumnName("DataLancamento")
            .IsRequired();

        builder
            .Property(controleLancamento => controleLancamento.TipoLancamento)
            .HasColumnType("varchar")
            .HasColumnName("TipoLancamento")
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(controleLancamento => controleLancamento.Cliente)
            .HasColumnType("varchar")
            .HasColumnName("Cliente")
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(controleLancamento => controleLancamento.Valor)
            .HasColumnType("decimal")
            .HasColumnName("Valor")
            .IsRequired();
    }
}