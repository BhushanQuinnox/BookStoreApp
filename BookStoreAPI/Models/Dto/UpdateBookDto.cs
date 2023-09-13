
namespace BookStoreAPI.Models.Dto;

public class UpdateBookDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public string ISBN { get; set; }
}