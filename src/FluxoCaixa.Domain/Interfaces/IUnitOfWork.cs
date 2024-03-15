namespace ControleFluxoCaixa.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<ControleLancamento> ControleLancamentos { get; }

    Task SaveChangesAsync();
}