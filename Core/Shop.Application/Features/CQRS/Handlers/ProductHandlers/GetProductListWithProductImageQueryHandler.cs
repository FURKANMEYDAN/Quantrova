using Shop.Application.Features.CQRS.Queries.ProductQueries;
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
    
    public class GetProductListWithProductImageQueryHandler
    {
        private readonly IRepository<Product> _productRepository;

        public GetProductListWithProductImageQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetProductListWithProductImageQueryResult>> Handle(GetProductListWithProductImageQuery query)
        {
            var products = await _productRepository.GetAllAsync();

            var result = products.Select(p => new GetProductListWithProductImageQueryResult
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductImageUrl = p.ProductImageUrl,
               
            }).ToList();

            return result;
        }


    }
}
