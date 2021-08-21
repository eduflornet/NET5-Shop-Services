using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShopService.Api.ShoppingCart.Remote.Interface;
using ShopService.Api.ShoppingCart.Remote.Model;

namespace ShopService.Api.ShoppingCart.Remote.Service
{
    public class BookService:IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ResponseRemote> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/Book/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() {PropertyNameCaseInsensitive = true};
                    var bookRemote = JsonSerializer.Deserialize<BookRemote>(content, options);
                    return new ResponseRemote
                    {
                        Result = true,
                        BookRemote = bookRemote,
                        ErrorMessage = null
                    };
                }

                return new ResponseRemote
                {
                    Result = false,
                    BookRemote = null,
                    ErrorMessage = response.ReasonPhrase
                };

            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return new ResponseRemote
                {
                    Result = false,
                    BookRemote = null,
                    ErrorMessage = e.Message
                };

            }
        }
    }
}
