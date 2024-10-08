﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.CQRS.Commands.ProductCommands;
using Shop.Application.Features.CQRS.Handlers.ProductHandlers;
using Shop.Application.Features.CQRS.Queries.ProductQueries;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductListWithCategoryQueryHandler _getProductListWithCategoryQueryHandler;
        private readonly GetProductListWithProductImageQueryHandler _getProductListWithProductImageQueryHandler;    
        public ProductsController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductListWithCategoryQueryHandler getProductListWithCategoryQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductListWithCategoryQueryHandler = getProductListWithCategoryQueryHandler;
              
            
        }

        public ProductsController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductListWithCategoryQueryHandler getProductListWithCategoryQueryHandler, GetProductListWithProductImageQueryHandler getProductListWithProductImageQueryHandler) : this(getProductQueryHandler, getProductByIdQueryHandler, createProductCommandHandler, updateProductCommandHandler, removeProductCommandHandler, getProductListWithCategoryQueryHandler)
        {
            _getProductListWithProductImageQueryHandler = getProductListWithProductImageQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetProductListWithCategory")]
        public async Task<IActionResult> GetProductListWithCategory()
        {

            var values = await _getProductListWithCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetProductListWithProductImages")]
        public async Task<IActionResult> GetProductListWithProductImages()
        {

            var values = await _getProductListWithProductImageQueryHandler.Handle();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok("The product has been created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return Ok("The product has been updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return Ok("The product has been deleted successfully");
        }
    }

}
