﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Commands.CategoryDetailCommands
{
    public class UpdateCategoryDetailCommand
    {
        public string ImageUrl { get; set; }
        public int CategoryDetailId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDetailName { get; set; }
    }
}
