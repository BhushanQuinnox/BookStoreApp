using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data;

public class BookApiContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    
    public BookApiContext(DbContextOptions options) : base(options)
    {
        //LoadBooks();
    }
    
    private void LoadBooks()
    {
        List<Book> bookList = new List<Book>()
        {
            new Book(){BookId = 1, Title = "Wings Of Fire", AuthorName = "APJ Abdul Kalam", Price = 220, ISBN = "abcd-efgh-uith-opit"},
            new Book(){BookId = 2, Title = "Goshti Manasanchya", AuthorName = "Sudha Murti", Price = 190, ISBN = "pqrs-vbhj-rtyu-oitr"},
            new Book(){BookId = 3, Title = "Batatyachi Chal", AuthorName = "P L Deshpande", Price = 310, ISBN = "vbhu-asfg-iutg-mjkl"}
        };

        Books.AddRange(bookList);
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Book>().HasData(
    //         new Book(){BookId = 1, Title = "Wings Of Fire", AuthorName = "APJ Abdul Kalam", Price = 220, ISBN = "abcd-efgh-uith-opit"},
    //         new Book(){BookId = 2, Title = "Goshti Manasanchya", AuthorName = "Sudha Murti", Price = 190, ISBN = "pqrs-vbhj-rtyu-oitr"},
    //         new Book(){BookId = 3, Title = "Batatyachi Chal", AuthorName = "P L Deshpande", Price = 310, ISBN = "vbhu-asfg-iutg-mjkl"}
    //     );
    // }

    public List<Book> GetBooks()  
    {  
        return Books.ToList();  
    } 
}