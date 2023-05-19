using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DGII_PruebaTecnica.Infrastructure.Data
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }


        public async Task<IEnumerable<T>> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include)
        {
            return await _dbSet.Include(include).Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include)
        {
            //add includes in dbSet
            try
            {
                IQueryable<T> query = _dbSet;
                foreach (var property in include)
                {
                    query = query.Include(property);
                }

                return await query.Where(predicate).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        Task<T> IRepository<T>.GetById(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include)
        {
            return await _dbSet.Include(include).Where(predicate).FirstAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbSet;
            foreach (var property in include)
            {
                query = query.Include(property);
            }

            return await query.Where(predicate).FirstAsync();
        }

        public async Task<T> Add(T entity)
        {
            try
            {

                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }
}
