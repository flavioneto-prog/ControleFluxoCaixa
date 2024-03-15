using ControleFluxoCaixa.Domain.Entities;
using ControleFluxoCaixa.Domain.Interfaces;

namespace FluxoCaixa.Application.Services;

public class AdicionarFluxoCaixaService : IAdicionarFluxoCaixaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private ILogger<AdicionarFluxoCaixaService> _logger;

    public AdicionarFluxoCaixaService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AdicionarFluxoCaixaService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<LancarFluxoCaixaResponse> AdicionarAsync(LancarFluxoCaixaRequest request)
    {
        try
        {
            var fluxoCaixaInserido = await _unitOfWork.ControleLancamentos.InsertAsync(_mapper.Map<ControleLancamento>(request));
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LancarFluxoCaixaResponse>(fluxoCaixaInserido);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao {nameof(AdicionarAsync)} lancamento de fluxo de caixa com a seguinte excecao: {ex}");
            throw;
        }
    }
}