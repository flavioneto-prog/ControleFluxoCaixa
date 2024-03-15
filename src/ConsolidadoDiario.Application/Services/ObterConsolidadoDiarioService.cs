using ConsolidadoDiario.Application.Models.Responses;
using ControleFluxoCaixa.Domain.Enums;
using ControleFluxoCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConsolidadoDiario.Application.Services;

public class ObterConsolidadoDiarioService : IObterConsolidadoDiarioService
{
    private ILogger<ObterConsolidadoDiarioService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ObterConsolidadoDiarioService(IUnitOfWork unitOfWork, ILogger<ObterConsolidadoDiarioService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<ConsolidadoResponse> ObterConsolidadoDiarioAsync(DateTime data)
    {
        try
        {
            var controleLancamentosDiario = await _unitOfWork.ControleLancamentos.GetAllAsync(s => s.DataLancamento.Date == data.Date, null, null);
            var valoresDebito = controleLancamentosDiario.Where(s => s.TipoLancamento == ETipoLancamento.Debito).Sum(s => s.Valor);
            var valoresCredito = controleLancamentosDiario.Where(s => s.TipoLancamento == ETipoLancamento.Credito).Sum(s => s.Valor);
            var consolidadoResponse = new ConsolidadoResponse(valoresDebito - valoresCredito);
            return consolidadoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao {nameof(ObterConsolidadoDiarioAsync)} com a seguinte excecao: {ex}");
            throw;
        }
    }
}