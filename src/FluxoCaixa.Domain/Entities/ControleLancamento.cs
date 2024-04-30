namespace ControleFluxoCaixa.Domain.Entities;

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

    public long Id { get; private set; }

    public DateTime DataLancamento { get; private set; }

    public ETipoLancamento TipoLancamento { get; private set; }

    public string Cliente { get; private set; }

    public decimal Valor { get; private set; }

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