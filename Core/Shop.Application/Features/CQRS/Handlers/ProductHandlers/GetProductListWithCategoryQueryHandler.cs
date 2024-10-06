using Shop.Application.Features.CQRS.Queries.ProductQueries;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.CQRS.Handlers.ProductHandlers
{

    public class GetProductListWithCategoryQueryHandler
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<CategoryDetail> _categoryDetailRepository;

        public GetProductListWithCategoryQueryHandler(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<CategoryDetail> categoryDetailRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _categoryDetailRepository = categoryDetailRepository;
        }

        public async Task<List<GetProductListWithCategoryQuery>> Handle()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDetails = await _categoryDetailRepository.GetAllAsync();

            var query = from p in products
                        join c in categories on p.CategoryId equals c.CategoryId
                        join cd in categoryDetails on p.CategoryDetailId equals cd.CategoryDetailId
                        select new GetProductListWithCategoryQuery
                        {
                            ProductId = p.ProductId,
                            CategoryName = c.CategoryName,
                            ProductName = p.ProductName,
                            CategoryDetailName = cd.CategoryDetailName,
                            Category = c,
                            CategoryDetail = cd
                        };
            return query.ToList();
        }


    }

}
