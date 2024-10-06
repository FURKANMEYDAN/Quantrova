using Shop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class RemoveCategoryDetailCommandHandler
    {

        private readonly IRepository<CategoryDetail> _repository;

        public RemoveCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
