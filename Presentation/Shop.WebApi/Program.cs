using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers;
using Shop.Application.Features.CQRS.Handlers.CategoryHandlers;
using Shop.Application.Features.CQRS.Handlers.ProductHandlers;
using Shop.Application.Features.CQRS.Queries.ProductQueries;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Persistence;
using Shop.Persistence.Context;
using Shop.WebApi.Repository;
using Shop.WebApi.Services.LoggerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopContext>(opt =>
{
    opt.UseNpgsql(connectionString);

});
builder.Host.UseSerilog((context, conf) =>
{
    conf.ReadFrom.Configuration(context.Configuration);
});

//Product
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<GetProductListWithCategoryQueryHandler>();
builder.Services.AddScoped<GetProductListWithProductImageQueryHandler>();

//Category
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
//CategoryDetails
builder.Services.AddScoped<CreateCategoryDetailCommandHandler>();
builder.Services.AddScoped<GetCategoryDetailByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryDetailQueryHandler>();
builder.Services.AddScoped<RemoveCategoryDetailCommandHandler>();
builder.Services.AddScoped<UpdateCategoryDetailCommandHandler>();
builder.Services.AddScoped<GetCategoryDetailWithCategoryQueryHandler>();

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
