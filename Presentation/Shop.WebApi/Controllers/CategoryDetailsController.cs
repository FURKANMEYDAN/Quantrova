using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.CQRS.Commands.CategoryCommands;
using Shop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using Shop.Application.Features.CQRS.Handlers.CategoryDetailHandlers;
using Shop.Application.Features.CQRS.Handlers.CategoryHandlers;
using Shop.Application.Features.CQRS.Queries.CategoryDetailQueries;
using Shop.Application.Features.CQRS.Queries.CategoryQueries;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailsController : ControllerBase
    {
        private readonly GetCategoryDetailQueryHandler _getCategoryDetailQueryHandler;
        private readonly GetCategoryDetailByIdQueryHandler _getCategoryDetailByIdQueryHandler;
        private readonly CreateCategoryDetailCommandHandler _createCategoryDetailCommandHandler;
        private readonly UpdateCategoryDetailCommandHandler _updateCategoryDetailCommandHandler;
        private readonly RemoveCategoryDetailCommandHandler _removeCategoryDetailCommandHandler;
        private readonly GetCategoryDetailWithCategoryQueryHandler _getCategoryDetailWithCategoryQueryHandler;

        public CategoryDetailsController(GetCategoryDetailQueryHandler getCategoryDetailQueryHandler, GetCategoryDetailByIdQueryHandler getCategoryDetailByIdQueryHandler, CreateCategoryDetailCommandHandler createCategoryDetailCommandHandler, UpdateCategoryDetailCommandHandler updateCategoryDetailCommandHandler, RemoveCategoryDetailCommandHandler removeCategoryDetailsCommandHandler, GetCategoryDetailWithCategoryQueryHandler getCategoryDetailWithCategoryQueryHandler)
        {
            _getCategoryDetailQueryHandler = getCategoryDetailQueryHandler;
            _getCategoryDetailByIdQueryHandler = getCategoryDetailByIdQueryHandler;
            _createCategoryDetailCommandHandler = createCategoryDetailCommandHandler;
            _updateCategoryDetailCommandHandler = updateCategoryDetailCommandHandler;
            _removeCategoryDetailCommandHandler = removeCategoryDetailsCommandHandler;
            _getCategoryDetailWithCategoryQueryHandler = getCategoryDetailWithCategoryQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryDetailQueryHandler.Handle();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _getCategoryDetailByIdQueryHandler.Handle(new GetCategoryDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDetailCommand command)
        {
            await _createCategoryDetailCommandHandler.Handle(command);
            return Ok("The Category has been created successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDetailCommand command)
        {
            await _updateCategoryDetailCommandHandler.Handle(command);
            return Ok("The Category has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryDetailCommandHandler.Handle(new RemoveCategoryDetailCommand(id));
            return Ok("The Category has been deleted successfully");
        }

        [HttpGet("GetCategoryDetailWithCategory")]
        public async Task<IActionResult> GetCategoryDetailWithCategory()
        {
            var result = await _getCategoryDetailWithCategoryQueryHandler.Handle();
            return Ok(result);
        }
    }

}
