using ControleFluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Profiles;

public class ControleLancamentoProfile : Profile
{
    public ControleLancamentoProfile()
    {
        CreateMap<LancarFluxoCaixaResponse, ControleLancamento>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => $"{src.Cliente}"))
            .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => $"{src.DataLancamento}"))
            .ForMember(dest => dest.TipoLancamento, opt => opt.MapFrom(src => $"{src.TipoLancamento}"))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => $"{src.Valor}"))
        .ReverseMap();
    }
}