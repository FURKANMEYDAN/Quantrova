﻿using Shop.Application.Features.CQRS.Commands.ProductCommands;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateProductCommand updateProductCommand)
        {

            var value = await _repository.GetByIdAsync(updateProductCommand.ProductId);
            value.ProductName = updateProductCommand.ProductName;
            value.ProductDescription = updateProductCommand.ProductDescription;
            value.ProductPrice = updateProductCommand.ProductPrice;
            value.ProductImageUrl = updateProductCommand.ProductImageUrl;
            value.CategoryId = updateProductCommand.CategoryId;
            value.CategoryDetailId = updateProductCommand.CategoryDetailId;

            await _repository.UpdataAsync(value);
        }
    }
}
