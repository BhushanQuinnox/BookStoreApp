
using System.Text.Json;

namespace BookStoreAPI.Models;

public class ErrorModel
{
    public string Status { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}