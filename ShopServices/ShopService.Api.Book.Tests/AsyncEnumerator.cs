using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopService.Api.Book.Tests
{
    // basically this class will evaluate the list that EF returns
    public class AsyncEnumerator<T>:IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public AsyncEnumerator(IEnumerator<T> enumerator) => this.enumerator = enumerator ?? throw new ArgumentException();
        

        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(enumerator.MoveNext());
        }

        public T Current => enumerator.Current;
    }
}
