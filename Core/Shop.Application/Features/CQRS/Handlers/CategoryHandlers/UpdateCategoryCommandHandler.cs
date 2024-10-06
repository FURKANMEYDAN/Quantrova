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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {

            var value = await _repository.GetByIdAsync(updateCategoryCommand.CategoryId);
            value.CategoryId = updateCategoryCommand.CategoryId;
            value.CategoryName = updateCategoryCommand.CategoryName;
            await _repository.UpdataAsync(value);
        }
    }
}
