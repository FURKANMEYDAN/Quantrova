using Microsoft.EntityFrameworkCore;
using Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers;
using Shop.Application.Features.CQRS.Handlers.CategoryHandlers;
using Shop.Application.Features.CQRS.Handlers.ProductHandlers;
using Shop.Application.Interfaces;
using Shop.Persistence;
using Shop.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopContext>(opt =>
{
    opt.UseNpgsql(connectionString);

});


//Product
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<GetProductListWithCategoryQueryHandler>();
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


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
