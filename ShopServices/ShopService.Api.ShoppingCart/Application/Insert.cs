using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopService.Api.ShoppingCart.Model;
using ShopService.Api.ShoppingCart.Persistence;

namespace ShopService.Api.ShoppingCart.Application
{
    public class Insert
    {
        public class Execute : IRequest
        {
            public DateTime SessionCreationDate { get; set; }
            public List<string> ProductList { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly CartContext _cartContext;

            public Handler(CartContext context)
            {
                _cartContext = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cartSession = new CartSession
                {
                    CreationDate = request.SessionCreationDate

                };
                _cartContext.Add(cartSession);
                var value = await _cartContext.SaveChangesAsync();
                if(value == 0) throw new Exception("An error occurred in the shopping cart insert");
                int cartSessionId = cartSession.CartSessionId;
                foreach (var product in request.ProductList)
                {
                    var cartSessionDetail = new CartSessionDetail
                    {
                        CreationDate = DateTime.Now,
                        CartSessionId = cartSessionId,
                        SelectedProduct = product
                    };
                    _cartContext.ShoppingCartSessionDetail.Add(cartSessionDetail);

                }

                value = await _cartContext.SaveChangesAsync();
                if (value > 0) return Unit.Value;
                throw new Exception("An error occurred in the insert of the shoppingCartSessionDetail");

            }
        }
    }
}
