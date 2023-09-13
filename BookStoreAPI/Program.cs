using BookStoreAPI.Data;
using BookStoreAPI.Filters;
using BookStoreAPI.Mapper;
using BookStoreAPI.Repositories;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddBookValidator>();
builder.Services.AddControllers( x =>
{
    x.Filters.Add(typeof(ExceptionFilter));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookApiContext>(opt => opt.UseInMemoryDatabase("BookApi")
                                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddTransient<BookApiContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
