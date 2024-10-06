using Shop.Application.Features.CQRS.Commands.CategoryCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCategoryCommand createCategoryCommand)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = createCategoryCommand.CategoryName,
            });

        }
    }
}
