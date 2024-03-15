namespace ControleFluxoCaixa.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleFluxoCaixaDbContext _dbContext;
        private IGenericRepository<ControleLancamento> _controleLancamentos;

        public UnitOfWork(ControleFluxoCaixaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<ControleLancamento> ControleLancamentos => _controleLancamentos ??= new GenericRepository<ControleLancamento>(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}