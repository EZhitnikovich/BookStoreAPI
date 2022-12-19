using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Categories.Queries.CategoryList
{
    internal class CategoryLookupDto: IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupDto>()
                .ForMember(categVm => categVm.Id,
                    opt => opt.MapFrom(categ => categ.Id))
                .ForMember(categVm => categVm.Title,
                    opt => opt.MapFrom(categ => categ.Title));
        }
    }
}