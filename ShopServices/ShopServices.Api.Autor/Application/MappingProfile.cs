using AutoMapper;
using ShopServices.Api.Author.Model;

namespace ShopServices.Api.Author.Application
{
    public class MappingProfile:Profile
    {
        // all the mappings needed to convert the properties of the EF Core entities are added
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorDto>();
        }
    }
}
