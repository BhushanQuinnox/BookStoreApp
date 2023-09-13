using BookStoreAPI.Models;
using BookStoreAPI.Models.Dto;
using FluentValidation;

namespace BookStoreAPI.Validation;

public class AddBookValidator : AbstractValidator<AddBookDto>
{
    public AddBookValidator()
    {
        RuleFor(t => t.Title).NotNull().NotEmpty().WithMessage("Title should not be null or empty");
        RuleFor(t => t.ISBN).NotEmpty().Matches(@"ISBN\x20(?=.{13}$)\d{1,5}([- ])\d{1,7}\1\d{1,6}\1(\d|X)$")
                            .WithMessage("Please check ISBN format");
    }
}