using AutoMapper;
using MinimalProductApi.Dtos;
using MinimalProductApi.Entities;

namespace MinimalProductApi.MapperConfigs
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
