using ConsolidadoDiario.Application.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace ConsolidadoDiario.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
public class ConsolidadosController : BaseController
{
    private readonly ILogger<ConsolidadosController> _logger;
    private readonly IObterConsolidadoDiarioService _obterConsolidadoDiarioService;

    public ConsolidadosController(ILogger<ConsolidadosController> logger, IObterConsolidadoDiarioService obterConsolidadoDiarioService)
    {
        _logger = logger;
        _obterConsolidadoDiarioService = obterConsolidadoDiarioService;
    }

    [SwaggerOperation(Summary = "Obter consolidado diario", Description = "Rota disponivel para buscar o relatório consolidado diario")]
    [SwaggerResponse(200, "Objeto de retorno", typeof(ConsolidadoResponse))]
    [HttpGet("diario")]
    public async Task<IActionResult> ObterRelatorioConsolidadoAsync([FromQuery][Required] DateTime data)
    {
        _logger.LogInformation("Data informada: {data}", data);
        var consolidado = await _obterConsolidadoDiarioService.ObterConsolidadoDiarioAsync(data);
        return Ok(consolidado);
    }
}