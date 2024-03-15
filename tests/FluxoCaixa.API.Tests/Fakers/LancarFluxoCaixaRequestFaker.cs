using Bogus;

namespace FluxoCaixa.API.Tests.Fakers;

public class LancarFluxoCaixaRequestFaker : Faker<LancarFluxoCaixaRequest>
{
    public LancarFluxoCaixaRequestFaker()
    {
        RuleFor(o => o.Cliente, f => f.Random.String(length: 60));
        RuleFor(o => o.DataLancamento, f => f.Date.Recent(0));
        RuleFor(o => o.TipoLancamento, f => f.PickRandom<ETipoLancamento>());
        RuleFor(o => o.Valor, f => f.Random.Decimal(0m, decimal.MaxValue));
    }
}