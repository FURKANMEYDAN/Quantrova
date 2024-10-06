using Shop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class CreateCategoryDetailCommandHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public CreateCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCategoryDetailCommand createCategoryDetailsCommand)
        {
            await _repository.CreateAsync(new CategoryDetail
            {
                CategoryDetailName = createCategoryDetailsCommand.CategoryDetailName,
                CategoryId= createCategoryDetailsCommand.CategoryId,
            });

        }
    }
}
