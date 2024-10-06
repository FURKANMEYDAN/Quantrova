using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Commands.CategoryDetailCommands
{
    public class CreateCategoryDetailCommand
    {
        public string CategoryDetailName { get; set; }
        public int CategoryId { get; set; }
    }
}
