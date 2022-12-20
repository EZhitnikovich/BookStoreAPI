using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Categories.Commands.CreateCategory;
using BookStore.Application.Common.Mapping;

namespace BookStore.WebApi.Models
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>();
        }
    }
}
