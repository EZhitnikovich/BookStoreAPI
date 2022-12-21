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
            if(context.Ratings.Any(x=>x.UserId == request.UserId && x.BookId == request.BookId))
            {
                return Guid.Empty;
            }

            var rating = new Rating
            {
                UserId = request.UserId,
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
