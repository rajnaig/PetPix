namespace Backend.Logic.Intefaces
{
    public interface ILogic <T>
    {
        void Create(T entity);
        void Update(T entity);
        T Delete(string id);
        T Get(string id);
        IQueryable<T> GetAll();

        void SaveChanges();
    }
}
