using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductListWithProductImagesAsync();
    }
}
