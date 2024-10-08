﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Result.CategoryDetailResults
{
    public class GetCategoryDetailQueryResult
    {
        public int CategoryDetailId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDetailName { get; set; }
        public string ImageUrl { get; set; }
    }
}
