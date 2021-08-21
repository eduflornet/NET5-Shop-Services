using System;

namespace ShopService.Api.ShoppingCart.Remote.Model
{
    public class BookRemote
    {
        public Guid? LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid? AuthorBookGuid { get; set; }
    }
}
