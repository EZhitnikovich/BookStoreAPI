using MediatR;

namespace BookStore.Application.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
