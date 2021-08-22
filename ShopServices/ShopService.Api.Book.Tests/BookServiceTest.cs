using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShopService.Api.Book.Application;
using ShopService.Api.Book.Model;
using ShopService.Api.Book.Persistence;
using Xunit;

namespace ShopService.Api.Book.Tests
{
    public class BookServiceTest
    {
        private List<LibraryMaterial> GetDataTest()
        {
            A.Configure<LibraryMaterial>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.LibraryMaterialId, () => { return Guid.NewGuid(); });

            var list = A.ListOf<LibraryMaterial>(30);
            list[0].LibraryMaterialId = Guid.Empty;
            return list;

        }

        private Mock<ContextLibrary> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();
            // Added simulation with all the necessary mechanism that requires Entity Framework
            // and what will consume the data test that was generated previously

            var dbSet = new Mock<DbSet<LibraryMaterial>>();
            dbSet.As<IQueryable<LibraryMaterial>>().Setup(x=>x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<LibraryMaterial>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<LibraryMaterial>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<LibraryMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            // AsyncEnumerable class and AsyncEnumerator allow me to asynchronously evaluate the list returned by Entity Framework context
            dbSet.As<IAsyncEnumerable<LibraryMaterial>>()
                .Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LibraryMaterial>(dataTest.GetEnumerator()));

            // Added configuration that is necessary to be able to make filters in the context of Entity Framework
            dbSet.As<IQueryable<LibraryMaterial>>().Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<LibraryMaterial>(dataTest.Provider));

            var contextLibrary = new Mock<ContextLibrary>();
            contextLibrary.Setup(x => x.LibraryMaterial).Returns(dbSet.Object);
            return contextLibrary;
        }

        [Fact]
        public async Task GetBookById()
        {
            var mockContext = CreateContext();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfileTest()));
            var mapper = mapperConfiguration.CreateMapper();
            var request = new QueryFilter.UniqueBook();
            request.BookId = Guid.Empty;
            var handler = new QueryFilter.Handler(mockContext.Object, mapper);
            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.LibraryMaterialId == Guid.Empty);

        }

        [Fact]
        public async Task GetBooks()
        {
            System.Diagnostics.Debugger.Launch();
            var mockContext = CreateContext();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfileTest()));
            var mapper = mapperConfiguration.CreateMapper(); 
            Query.Handler handler = new Query.Handler(mockContext.Object, mapper);
            Query.BookList request = new Query.BookList();
            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());

        }
    }
}
