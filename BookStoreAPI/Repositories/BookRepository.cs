using BookStoreAPI.Data;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookApiContext BookApiContext
    {
        get {return _context as BookApiContext; }
    }

    public BookRepository(BookApiContext context) : base(context)
    {
        
    }
}