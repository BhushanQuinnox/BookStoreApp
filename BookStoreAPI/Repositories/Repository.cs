

using BookStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity Get(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Put(int id, TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}