using System;
using System.Collections.Generic;

namespace ShopService.Api.ShoppingCart.Application
{
    public class CartDto
    {
        public int CartId { get; set; }
        public DateTime SessionCreationDate { get; set; }
        public List<CartDetailDto> ProductList { get; set; }

    }
}
