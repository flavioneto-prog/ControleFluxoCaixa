namespace FluxoCaixa.Application.Interfaces;

public interface IAdicionarFluxoCaixaService
{
    Task<LancarFluxoCaixaResponse> AdicionarAsync(LancarFluxoCaixaRequest request);
}