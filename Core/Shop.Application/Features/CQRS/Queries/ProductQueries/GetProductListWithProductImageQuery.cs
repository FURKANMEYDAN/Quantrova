using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Queries.ProductQueries
{
    public class GetProductListWithProductImageQuery : IRequest<List<Product>>
    {
        public int CategoryId {  get; set; }
        public int CategoryDetailId {  get; set; }

        public string ProductName { get; set; } 
        
        public string ProductImageUrl{ get; set; }
    }
}
