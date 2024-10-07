using Shop.Application.Features.CQRS.Queries.CategoryDetailQueries;
using Shop.Application.Features.CQRS.Result.CategoryDetailResults;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class GetCategoryDetailByIdQueryHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public GetCategoryDetailByIdQueryHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryDetailByIdQueryResult> Handle(GetCategoryDetailByIdQuery getCategoryDetailByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getCategoryDetailByIdQuery.Id);
            return new GetCategoryDetailByIdQueryResult
            {
                CategoryDetailId = value.CategoryDetailId,
                CategoryId = value.CategoryId,
                CategoryDetailName = value.CategoryDetailName,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
