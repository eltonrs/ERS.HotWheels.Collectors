using ERS.HotWheels.Collectors.Domain.Entities.Base;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories.Base;
using ERS.HotWheels.Collectors.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERS.HotWheels.Collectors.Infra.Data.Repository.Repositories.Base
{
    public abstract class RepositoryBase<TEntity>(HotWheelsCollectorsContext context) // < Primary ctor
        : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly HotWheelsCollectorsContext _context = context;
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public void Add(TEntity entity)
            => _dbSet.Add(entity);

        public async Task<TEntity?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default
        )
            => await _dbSet
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public void Delete(TEntity entity)
            => _dbSet.Remove(entity);

        public void DeleteById(Guid id)
        {
            var entity = _dbSet.Find($"id,{id}"); // ToDo : Is this right?

            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
        }

        public int Save()
            => _context.SaveChanges();
    }
}
