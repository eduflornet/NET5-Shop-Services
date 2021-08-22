using AutoMapper;
using ShopService.Api.Book.Application;
using ShopService.Api.Book.Model;

namespace ShopService.Api.Book.Tests
{
    public class MappingProfileTest:Profile
    {
        public MappingProfileTest()
        {
            CreateMap<LibraryMaterial, BookDto>();
        }
    }
}
