using Backend.Repository.Interfaces;

namespace Backend.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
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
            throw new NotImplementedException();
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
