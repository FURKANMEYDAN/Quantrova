using Shop.Application.Features.CQRS.Queries.CategoryDetailQueries;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
   
    public class GetCategoryDetailWithCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<CategoryDetail> _categoryDetailRepository;

        public GetCategoryDetailWithCategoryQueryHandler(IRepository<Category> categoryRepository, IRepository<CategoryDetail> categoryDetailRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryDetailRepository = categoryDetailRepository;
        }

        public async Task<List<GetCategoryDetailWithCategoryQuery>> Handle()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDetail = await _categoryDetailRepository.GetAllAsync();
            var query = from c in categories
                        join cd in categoryDetail on c.CategoryId equals cd.CategoryId
                        select new GetCategoryDetailWithCategoryQuery
                        {
                            CategoryId = c.CategoryId,
                            CategoryName = c.CategoryName,
                            CategoryDetailId = cd.CategoryDetailId,
                            CategoryDetailName = cd.CategoryDetailName,
                            Category = c
                        };


            return query.ToList();
        }

    }
}
