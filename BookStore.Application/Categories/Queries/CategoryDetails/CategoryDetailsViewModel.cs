using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Categories.Queries.CategoryDetails
{
    public class CategoryDetailsViewModel : IMapWith<Category>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailsViewModel>()
                .ForMember(categVm => categVm.Title,
                    opt => opt.MapFrom(categ => categ.Title))
                .ForMember(categVm => categVm.Description,
                    opt => opt.MapFrom(categ => categ.Description));
        }
    }
}
