namespace ERS.HotWheels.Collectors.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity FindById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity entity);
        void DeleteById(Guid id);
        void Update(TEntity entity);
    }
}