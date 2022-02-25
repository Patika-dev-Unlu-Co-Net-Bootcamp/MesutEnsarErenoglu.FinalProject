using AutoMapper;
using FinalProject.Application.DTOs;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<Color, ColorDto>().ReverseMap();

            CreateMap<Category, CategoryDto>()
               .ReverseMap();

            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(dest=> dest.Category, act=> act.Ignore())
                .ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SubCategory, act => act.Ignore())
                .ForMember(dest => dest.AppUser, act => act.Ignore())
                .ReverseMap();

            CreateMap<AppUser, AppUserDto>()
                .ReverseMap();

            CreateMap<Bid, BidDto>()
                .ForMember(dest=> dest.BidderAppUser,act=>act.MapFrom(src=>src.BidderAppUser))
                .ForMember(dest=>dest.Product,act=>act.MapFrom(src=>src.Product))
                .ReverseMap();

        }
    }
}
