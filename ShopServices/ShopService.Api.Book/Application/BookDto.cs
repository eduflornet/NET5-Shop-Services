using System;

namespace ShopService.Api.Book.Application
{
    public class BookDto
    {
        public Guid? LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid? AuthorBookGuid { get; set; }
    }
}
