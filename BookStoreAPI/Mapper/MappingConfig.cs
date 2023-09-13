using AutoMapper;
using BookStoreAPI.Models;
using BookStoreAPI.Models.Dto;
namespace BookStoreAPI.Mapper;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Book, AddBookDto>().ReverseMap();
        CreateMap<UpdateBookDto, Book>();
    }
}