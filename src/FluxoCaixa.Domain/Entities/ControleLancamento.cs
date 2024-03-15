namespace ControleFluxoCaixa.Domain.Entities;

[Table(name: "TB_CONTROLE_LANCAMENTO")]
public record class ControleLancamento
{
    public ControleLancamento()
    {
    }

    public ControleLancamento
    (
        long id,
        DateTime dataLancamento,
        ETipoLancamento tipoLancamento,
        string cliente,
        decimal Valor
    )
    {
        PreencherControleLancamento(id, dataLancamento, tipoLancamento, cliente, Valor);
    }

    [Key]
    public long Id { get; private set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime DataLancamento { get; private set; }

    [Required]
    [Column(TypeName = "varchar(60)")]
    public ETipoLancamento TipoLancamento { get; private set; }

    [Required]
    [StringLength(60)]
    [Column("varchar(60)")]
    public string Cliente { get; private set; }

    [Required]
    [Column(TypeName = "decimal")]
    public decimal Valor { get; private set; }

    public static void ValidarInformacoesControleLancamento()
    {

    }

    public void PreencherControleLancamento
    (
        long id,
        DateTime dataLancamento,
        ETipoLancamento tipoLancamento,
        string cliente,
        decimal valor
    )
    {
        Id = id;
        DataLancamento = dataLancamento;
        TipoLancamento = tipoLancamento;
        Cliente = cliente;
        Valor = valor;
    }
}