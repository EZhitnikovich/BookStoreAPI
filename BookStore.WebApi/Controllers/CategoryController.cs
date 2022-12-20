using AutoMapper;
using BookStore.Application.Categories.Commands.CreateCategory;
using BookStore.Application.Categories.Commands.DeleteCategory;
using BookStore.Application.Categories.Commands.UpdateCategory;
using BookStore.Application.Categories.Queries.CategoryDetails;
using BookStore.Application.Categories.Queries.CategoryList;
using BookStore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IMapper mapper;

        public CategoryController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryListViewModel>> GetAll()
        {
            var query = new GetCategoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<CategoryDetailsViewModel>> Get(Guid id)
        {
            var query = new GetCategoryDetailsQuery()
            {
                Id = id
            };
            var rm = await Mediator.Send(query);
            return Ok(rm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = mapper.Map<CreateCategoryCommand>(createCategoryDto);
            var categoryId = await Mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}