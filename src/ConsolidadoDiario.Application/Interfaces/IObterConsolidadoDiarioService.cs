using ConsolidadoDiario.Application.Models.Responses;

namespace ConsolidadoDiario.Application.Interfaces;

public interface IObterConsolidadoDiarioService
{
    Task<ConsolidadoResponse> ObterConsolidadoDiarioAsync(DateTime data);
}