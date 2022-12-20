using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Application.Ratings.Commands.CreateRating;

namespace BookStore.WebApi.Models
{
    public class CreateRatingDto: IMapWith<CreateRatingCommand>
    {
        public Guid BookId { get; set; }
        public int Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRatingDto, CreateRatingCommand>();
        }
    }
}
