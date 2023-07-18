using Backend.Data;
using Backend.Repository.Interfaces;

namespace Backend.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(string uId)
        {
            throw new NotImplementedException();
        }

        public T Get(string uId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> items = _ctx.Set<T>();
            return items;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
