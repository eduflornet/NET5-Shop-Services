using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopService.Api.ShoppingCart.Persistence;
using ShopService.Api.ShoppingCart.Remote.Interface;

namespace ShopService.Api.ShoppingCart.Application
{
    public class Query
    {
        public class Execute:IRequest<CartDto> {
            public int CartSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, CartDto>
        {
            private readonly CartContext _cartContext;
            private readonly IBookService _bookService;

            public Handler(CartContext cartContext, IBookService bookService)
            {
                _cartContext = cartContext;
                _bookService = bookService;
            }

            public async Task<CartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cartSession = await
                    _cartContext.CartSession.FirstOrDefaultAsync(x => x.CartSessionId == request.CartSessionId);
                var cartSessionDetail = await _cartContext.ShoppingCartSessionDetail
                    .Where(x => x.CartSessionId == request.CartSessionId).ToListAsync();
                var cartDetailDtoList = new List<CartDetailDto>();

                foreach (var book in cartSessionDetail)
                {
                    var responseRemote = await _bookService.GetBook(new Guid(book.SelectedProduct));
                    if (responseRemote.Result)
                    {
                        
                        var cartDetailDto = new CartDetailDto
                        {
                            PublicationDate = responseRemote.BookRemote.PublicationDate,
                            BookId = responseRemote.BookRemote.LibraryMaterialId,
                            BookTitle = responseRemote.BookRemote.Title
                        };
                        cartDetailDtoList.Add(cartDetailDto);
                    }

                }

                var cartDto = new CartDto
                {
                    CartId = cartSession.CartSessionId,
                    SessionCreationDate = cartSession.CreationDate,
                    ProductList = cartDetailDtoList
                };

                return cartDto;

            }
        }
    }
}
