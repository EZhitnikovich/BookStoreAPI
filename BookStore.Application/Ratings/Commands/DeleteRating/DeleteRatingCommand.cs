using MediatR;

namespace BookStore.Application.Ratings.Commands.DeleteRating
{
    internal class DeleteRatingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
