using Shop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class UpdateCategoryDetailCommandHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public UpdateCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryDetailCommand updateCategoryDetailsCommand)
        {

            var value = await _repository.GetByIdAsync(updateCategoryDetailsCommand.CategoryDetailId);
            value.CategoryDetailName = updateCategoryDetailsCommand.CategoryDetailName;
            value.CategoryDetailId = updateCategoryDetailsCommand.CategoryDetailId;
            value.CategoryId = updateCategoryDetailsCommand.CategoryId;
            await _repository.UpdataAsync(value);
        }
    }
}
