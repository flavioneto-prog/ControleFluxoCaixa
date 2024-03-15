namespace FluxoCaixa.API.Tests;

public class LancamentosControllerTests
{
    private readonly LancamentosController _lancamentosController;
    private readonly ILogger<LancamentosController> _logger;
    private readonly IAdicionarFluxoCaixaService _adicionarLancamentoFluxoCaixaService;
    private readonly LancarFluxoCaixaRequestFaker _faker;

    public LancamentosControllerTests()
    {
        _logger = Substitute.For<ILogger<LancamentosController>>();
        _adicionarLancamentoFluxoCaixaService = Substitute.For<IAdicionarFluxoCaixaService>();
        _faker = new LancarFluxoCaixaRequestFaker();
        _lancamentosController = new LancamentosController(_logger, _adicionarLancamentoFluxoCaixaService);
    }

    internal void ValidarObjeto()
    {
        var objectValidator = new Mock<IObjectModelValidator>();
        objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(), It.IsAny<ValidationStateDictionary>(), It.IsAny<string>(), It.IsAny<object>()));
        _lancamentosController.ObjectValidator = objectValidator.Object;
    }

    [Fact]
    public async void UmaRequisicaoValida_AdicionarFluxoDeCaixaAsync_RetornarMovimentacaoInseridaESucesso()
    {
        // Arrange
        var responseCode = 201;
        var request = _faker.Generate();
        ValidarObjeto();

        _adicionarLancamentoFluxoCaixaService.AdicionarAsync(Arg.Is(request)).Returns(new LancarFluxoCaixaResponse(1, request.Cliente, request.DataLancamento, request.TipoLancamento.ToString(), request.Valor));

        // Action
        var isModelStateValid = _lancamentosController.TryValidateModel(request);
        var resultado = await _lancamentosController.AdicionarFluxoDeCaixa(request);
        var createdActionResult = resultado as CreatedAtActionResult;

        // Assert
        Assert.True(isModelStateValid);
        Assert.Equal(responseCode, createdActionResult!.StatusCode);
        Assert.NotNull(resultado);
    }

    [Fact]
    public async void UmaRequisicaoInvalida_AdicionarFluxoDeCaixaAsync_RetornarErroEMotivo()
    {
        // Arrange
        var responseCode = 400;
        var request = _faker.Generate();
        request.Valor = -100;
        ValidarObjeto();

        _lancamentosController.ModelState.AddModelError("Valor", "o valor deve ser maior que zero");

        // Action
        var resultado = await _lancamentosController.AdicionarFluxoDeCaixa(request);
        var badRequestResult = resultado as BadRequestResult;

        // Assert
        Assert.Equal(responseCode, badRequestResult!.StatusCode);
    }
}