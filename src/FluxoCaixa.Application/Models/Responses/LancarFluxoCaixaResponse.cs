namespace FluxoCaixa.Application.Models.Responses;

public record class LancarFluxoCaixaResponse(long Id, string Cliente, DateTime DataLancamento, string TipoLancamento, decimal Valor);