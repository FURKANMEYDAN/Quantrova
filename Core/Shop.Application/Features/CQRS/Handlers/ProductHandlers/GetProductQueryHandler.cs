using Shop.Application.Features.CQRS.Result.ProductResults;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly IRepository<Product> _repository;

        public GetProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return  value.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                CategoryId = x.CategoryId,
                CategoryDetailId = x.CategoryDetailId,
                ProductName = x.ProductName,
              
            }).ToList();
        }
    }
}
