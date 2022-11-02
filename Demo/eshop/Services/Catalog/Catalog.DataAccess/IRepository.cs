using Catalog.Entities;

namespace Catalog.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Create(T entity);
        IList<T> GetAll();
        T GetEntityById(int id);


    }
}
