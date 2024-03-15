namespace ControleFluxoCaixa.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IList<T>> GetAllAsync(
        Expression<Func<T, bool>>? expression,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        List<string>? includes);

    Task<T?> GetAsync(
        Expression<Func<T, bool>> expression,
        List<string>? includes);

    Task<T> InsertAsync(T entity);
}