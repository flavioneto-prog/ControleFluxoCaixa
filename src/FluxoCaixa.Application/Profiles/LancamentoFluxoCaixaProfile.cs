using ControleFluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Profiles;

public class LancamentoFluxoCaixaProfile : Profile
{
    public LancamentoFluxoCaixaProfile()
    {
        CreateMap<LancarFluxoCaixaRequest, ControleLancamento>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => $"{src.Cliente}"))
            .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => $"{src.DataLancamento}"))
            .ForMember(dest => dest.TipoLancamento, opt => opt.MapFrom(src => $"{src.TipoLancamento}"))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => $"{src.Valor}"))
       .ReverseMap();
    }
}