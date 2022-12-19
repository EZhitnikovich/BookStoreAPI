using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandHandler
        : IRequestHandler<CreateRatingCommand, Guid>
    {
        private readonly IBookStoreDbContext context;

        public CreateRatingCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = new Rating
            {
                UserId = request.UserID,
                BookId = request.BookId,
                Value = request.Value,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null,
            };

            await context.Ratings.AddAsync(rating, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return rating.Id;
        }
    }
}
