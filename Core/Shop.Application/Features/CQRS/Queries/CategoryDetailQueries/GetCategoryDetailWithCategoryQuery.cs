using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Queries.CategoryDetailQueries
{
    public class GetCategoryDetailWithCategoryQuery
    {
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }

        public int CategoryDetailId {  get; set; }
        public string CategoryDetailName { get;set; }
        public Category Category { get; set; }
    }
}
