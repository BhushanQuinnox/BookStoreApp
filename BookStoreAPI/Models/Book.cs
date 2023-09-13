
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public string ISBN { get; set; }
}