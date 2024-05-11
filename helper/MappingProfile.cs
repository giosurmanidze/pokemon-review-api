using AutoMapper;
using pokemon_review_api.Dto;
using pokemon_review_api.Entities;

namespace pokemon_review_api.helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokemon, PokemonDto>();
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {src.Id}"));
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}