using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Books.Commands.CreateBook
{
    internal class CreateBookCommandHandler
        : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookStoreDbContext context;
        public CreateBookCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                CategoryId = request.CategoryId,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await context.Books.AddAsync(book, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
