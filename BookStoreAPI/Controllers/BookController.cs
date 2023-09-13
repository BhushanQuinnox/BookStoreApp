using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using BookStoreAPI.Models.Dto;
using BookStoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookController(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetAllBooks")]
    public ActionResult<List<Book>> GetAllBooks()
    {
        return Ok(_bookRepository.GetAll());
    }

    [HttpGet("id", Name = "GetBookById")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookRepository.Get(id);
        if(book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost(Name = "AddBook")]
    public ActionResult<Book> AddBook([FromBody]AddBookDto addBookDto)
    {
        if(addBookDto == null)
        {
            return BadRequest();
        }

        Book book = _mapper.Map<Book>(addBookDto);
        _bookRepository.Add(book);
        _bookRepository.Save();
        return CreatedAtRoute("GetBookById", new {id = book.BookId}, book);
    }

    [HttpPut("id", Name = "UpdateBook")]
    public IActionResult UpdateBook(int id, [FromBody]UpdateBookDto updateBookDto)
    {
        if(updateBookDto == null || id != updateBookDto.BookId)
        {
            return BadRequest();
        }
        
        if(_bookRepository.Get(id) == null)
        {
            return NotFound();
        }

        Book book = _mapper.Map<Book>(updateBookDto);
        _bookRepository.Put(id, book);
        _bookRepository.Save();
        return Ok();
    }

    [HttpDelete("id", Name = "DeleteBook")]
    public IActionResult DeleteBook(int id)
    {
        var book = _bookRepository.Get(id);
        if(book == null)
        {
            return NotFound();
        }

        _bookRepository.Remove(book);
        _bookRepository.Save();
        return Ok();
    }
}
