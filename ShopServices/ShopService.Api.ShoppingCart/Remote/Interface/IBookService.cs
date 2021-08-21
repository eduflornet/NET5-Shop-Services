using System;
using System.Threading.Tasks;
using ShopService.Api.ShoppingCart.Remote.Model;

namespace ShopService.Api.ShoppingCart.Remote.Interface
{
    public interface IBookService
    {
        Task<ResponseRemote> GetBook(Guid BookId);
    }
}
