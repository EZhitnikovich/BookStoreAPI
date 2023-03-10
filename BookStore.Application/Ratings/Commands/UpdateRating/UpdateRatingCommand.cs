using MediatR;

namespace BookStore.Application.Ratings.Commands.UpdateRating
{
    public class UpdateRatingCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Value { get; set; }
    }
}
