using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Interfaces
{
    public interface IRepository <T>
    {
        void Create(T entity);
        T Get (string uId);
        IQueryable<T> GetAll ();

        public void DeleteAll();
        void Update (T entity);
        T Delete (string uId);
        void SaveChanges();
    }
}
