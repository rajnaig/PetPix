using Backend.Data;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _ctx;
        private DbSet<T> _dbSet;


        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _ctx.SaveChanges();
        }

        public T Delete(string uId)
        {
            T? toDelete = _dbSet.Find(uId);
            if (toDelete == null)
            {
                throw new Exception($"{nameof(Repository)}/Delete: Couldn't find item with the id {uId}");
            }
            _dbSet.Remove(toDelete);
            _ctx.SaveChanges();
            return toDelete;
        }

        public void DeleteAll()
        {
            var allEntities = _dbSet;
            _dbSet.RemoveRange(allEntities);
        }

        public T Get(string uId)
        {
            T? getItem = _dbSet.Find(uId);

            if (getItem == null)
            {
                throw new Exception($"{nameof(Repository)}/Get: Couldn't find item with the id {uId}");
            }

            return getItem;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> items = _ctx.Set<T>();
            return items;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
