using AutoMapper;

namespace BookStore.Application.Common.Mapping
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile)
            => profile.CreateMap(typeof(T), GetType());
    }
}
