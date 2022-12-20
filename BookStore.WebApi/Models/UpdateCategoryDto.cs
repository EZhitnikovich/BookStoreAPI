using AutoMapper;
using BookStore.Application.Categories.Commands.UpdateCategory;
using BookStore.Application.Common.Mapping;

namespace BookStore.WebApi.Models
{
    public class UpdateCategoryDto: IMapWith<UpdateCategoryCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
