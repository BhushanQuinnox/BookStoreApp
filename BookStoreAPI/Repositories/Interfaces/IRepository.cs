namespace BookStoreAPI.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void Remove(TEntity entity);
    void Put(int id, TEntity entity);
    int Save();
}