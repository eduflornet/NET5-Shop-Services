using AutoMapper;
using ShopService.Api.Book.Model;

namespace ShopService.Api.Book.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryMaterial, BookDto>();
        }
    }
}
