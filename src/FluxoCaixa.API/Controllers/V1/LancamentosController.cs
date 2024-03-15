namespace FluxoCaixa.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
public class LancamentosController : BaseController
{
    private readonly ILogger<LancamentosController> _logger;
    private readonly IAdicionarFluxoCaixaService _adicionarLancamentoFluxoCaixaService;

    public LancamentosController(ILogger<LancamentosController> logger, IAdicionarFluxoCaixaService adicionarLancamentoFluxoCaixaService)
    {
        _logger = logger;
        _adicionarLancamentoFluxoCaixaService = adicionarLancamentoFluxoCaixaService;
    }

    [HttpPost("movimentacao")]
    public async Task<IActionResult> AdicionarFluxoDeCaixa(LancarFluxoCaixaRequest request)
    {
        if (!TryValidateModel(request)) return ValidationProblem(ModelState);

        var fluxoCaixa = await _adicionarLancamentoFluxoCaixaService.AdicionarAsync(request);
        return CreatedAtAction(nameof(AdicionarFluxoDeCaixa), new { id = fluxoCaixa.Id }, fluxoCaixa);
    }
}