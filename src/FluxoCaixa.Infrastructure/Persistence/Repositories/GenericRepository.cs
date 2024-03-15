namespace ControleFluxoCaixa.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal ControleFluxoCaixaDbContext _dbContext;
    internal DbSet<T> _db;

    public GenericRepository(ControleFluxoCaixaDbContext dbContext)
    {
        _dbContext = dbContext;
        _db = _dbContext.Set<T>();
    }

    public async Task<T?> GetAsync(
        Expression<Func<T, bool>> expression,
        List<string>? includes)
    {
        IQueryable<T> query = _db;

        if (includes is not null)
        {
            if (includes.Any())
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<IList<T>> GetAllAsync(
        Expression<Func<T, bool>>? expression,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        List<string>? includes)
    {
        IQueryable<T> query = _db;

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if (includes is not null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        await _db.AddAsync(entity);
        return entity;
    }
}