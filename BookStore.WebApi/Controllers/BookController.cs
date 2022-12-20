using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Commands.DeleteBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Books.Queries.BookDetails;
using BookStore.Application.Books.Queries.GetBookList;
using BookStore.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper mapper;

        public BookController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookListViewModel>> GetAll()
        {
            var query = new GetBookListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<BookListByCategoryViewModel>> GetAll(Guid categoryId)
        {
            var query = new GetBookListByCategoryQuery
            {
                CategoryId = categoryId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<BookDetailsViewModel>> Get(Guid id)
        {
            var query = new GetBookDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = mapper.Map<UpdateBookCommand>(updateBookDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
