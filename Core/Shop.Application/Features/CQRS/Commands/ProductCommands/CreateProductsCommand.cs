﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public string ProductName { get; set; }
       
        public int CategoryId { get; set; }
        public int CategoryDetailId { get; set; }

        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
