namespace SimpleConsole.Mapping
{
    using AutoMapper;
    using SimpleConsole.Data;
    using SimpleConsole.Models;

    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, BlogExtra>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dest => dest.BlogExtendedName, opt => opt.MapFrom(src => src.BlogExtended.Name));
        }
    }
}
