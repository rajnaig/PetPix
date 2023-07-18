using Backend.Logic.Intefaces;
using Backend.Repository.Interfaces;

namespace Backend.Logic.Implementations
{
    public class Logic<T> : ILogic<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Logic(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
        }

        public T Delete(string id)
        {
            return _repository.Delete(id);
        }

        public T Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
