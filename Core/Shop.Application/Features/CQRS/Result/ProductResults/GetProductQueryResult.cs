using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Result.ProductResults
{
    public class GetProductQueryResult
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int CategoryDetailId { get; set; }
        public string ProductName { get; set; }
   
    }
}
