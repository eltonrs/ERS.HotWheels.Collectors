using ERS.HotWheels.Collectors.Domain.Entities.Base;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories.Base;
using ERS.HotWheels.Collectors.Infra.Context;

namespace ERS.HotWheels.Collectors.Infra.Data.Repository.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly HotWheelsCollectorsContext _context;

        public RepositoryBase(HotWheelsCollectorsContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteById(Guid id)
        {
            var entity = FindById(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity FindById(Guid id)
        {
            return _context
                .Set<TEntity>()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context
                .Set<TEntity>()
                .ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
