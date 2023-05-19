using System.Linq.Expressions;

namespace DGII_PruebaTecnica.Infrastructure.Interfaces
{


    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task<T> GetById(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include);
        Task<T> GetById(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include);
        Task<T> Add(T entity);
        void Delete(int id);
        Task<T> Update(T entity);
    }
}