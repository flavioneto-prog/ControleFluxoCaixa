using ConsolidadoDiario.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ConsolidadoDiario.Domain.Interfaces.Repositories;

namespace ConsolidadoDiario.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal ConsolidadoDiarioDbContext _dbContext;
    internal DbSet<T> _db;

    public GenericRepository(ConsolidadoDiarioDbContext dbContext)
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
}