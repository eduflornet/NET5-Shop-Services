using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopService.Api.Book.Model;
using ShopService.Api.Book.Persistence;

namespace ShopService.Api.Book.Application
{
    public class QueryFilter
    {
        public class UniqueBook : IRequest<BookDto>
        {
            public Guid? BookId { get; set; }
        }

        public class Handler : IRequestHandler<UniqueBook, BookDto>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;
            public Handler(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(UniqueBook request, CancellationToken cancellationToken)
            {
                var book = await _contextLibrary.LibraryMaterial.Where(x => x.LibraryMaterialId == request.BookId).FirstOrDefaultAsync();
                if(book == null) throw new Exception("The book was not found");

                var bookDto = _mapper.Map<LibraryMaterial, BookDto>(book);
                return bookDto;
            }
        }
    }
}
