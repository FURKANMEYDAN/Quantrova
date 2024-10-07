using Shop.Application.Features.CQRS.Result.CategoryDetailResults;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class GetCategoryDetailQueryHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public GetCategoryDetailQueryHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryDetailQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return  value.Select(x => new GetCategoryDetailQueryResult
            {
                CategoryDetailId = x.CategoryDetailId,
                CategoryId = x.CategoryId,
                CategoryDetailName = x.CategoryDetailName,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
