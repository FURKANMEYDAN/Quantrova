using Shop.Application.Features.CQRS.Commands.ProductCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateProductCommand createProductCommand)
        {
            await _repository.CreateAsync(new Product
            {
                ProductName = createProductCommand.ProductName,
                CategoryId = createProductCommand.CategoryId,
                CategoryDetailId = createProductCommand.CategoryDetailId,
                ProductPrice = createProductCommand.ProductPrice,   
                ProductImageUrl = createProductCommand.ProductImageUrl, 
                ProductDescription = createProductCommand.ProductDescription,   


                
            });

        }
    }
}
