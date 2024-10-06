using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Commands.CategoryDetailCommands
{
    public class RemoveCategoryDetailCommand
    {
        public RemoveCategoryDetailCommand(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
    }
}
