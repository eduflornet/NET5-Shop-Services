using System;
using System.Collections.Generic;

namespace ShopService.Api.ShoppingCart.Model
{
    public class CartSession
    {
        public int CartSessionId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<ShoppingCartSessionDetail> DetailList { get; set; }
    }
}
