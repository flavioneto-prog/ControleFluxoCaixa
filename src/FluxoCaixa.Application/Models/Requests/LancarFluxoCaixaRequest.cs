namespace FluxoCaixa.Application.Models.Requests;

public class LancarFluxoCaixaRequest
{
    [Required(ErrorMessage = "o nome do cliente é obrigatorio")]
    [StringLength(60, ErrorMessage = "O tamanho do nome do cliente nao pode exceder 60 caracteres")]
    public required string Cliente { get; set; }

    [Required(ErrorMessage = "a data de lancamento é obrigatoria")]
    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "o tipo de lancamento é obrigatorio")]
    public ETipoLancamento TipoLancamento { get; set; }

    [Required(ErrorMessage = "o valor é obrigatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "o valor deve ser maior que zero")]
    public decimal Valor { get; set; }
}