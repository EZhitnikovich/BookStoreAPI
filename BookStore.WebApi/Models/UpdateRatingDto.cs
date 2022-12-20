using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Application.Ratings.Commands.UpdateRating;

namespace BookStore.WebApi.Models
{
    public class UpdateRatingDto: IMapWith<UpdateRatingCommand>
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRatingDto, UpdateRatingCommand>();
        }
    }
}
