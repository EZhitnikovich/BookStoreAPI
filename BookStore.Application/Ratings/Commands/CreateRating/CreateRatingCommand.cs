using MediatR;

namespace BookStore.Application.Ratings.Commands.CreateRating
{
    public class CreateRatingCommand : IRequest<Guid>
    {
        public Guid UserID { get; set; }
        public Guid BookId { get; set; }
        public int Value { get; set; }
    }
}
