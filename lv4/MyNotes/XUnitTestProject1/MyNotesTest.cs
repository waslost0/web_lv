using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MyNotes;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class MyNotesTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public readonly WebApplicationFactory<Startup> _factory;
        public MyNotesTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home")]
        [InlineData("/Home/Privacy")]
        [InlineData("/Home/Index")]
        [InlineData("/Notes")]
        [InlineData("/Notes/Index")]
        [InlineData("/Notes/Edit/13")]
        public async Task GetHttpRequestAllPagesAvailable(string url)
        {

            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/notes/12")]
        public async Task GetNoteThroughApi_ReturnNote12(string url)
        {
            var client = _factory.CreateClient();

            string expected = "{\"id\":12,\"name\":\"Test\",\"description\":\"Nen\"}";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();


            Assert.Equal(expected, content.ToString());
        }


        [Theory]
        [InlineData("/api/notes/list")]
        public async Task GetNotesList(string url)
        {
            var client = _factory.CreateClient();

            string expected = "[{\"id\":12,\"name\":\"Test\",\"description\":\"Nen\"},{\"id\":13,\"name\":\"More\",\"description\":\"TED\\r\\nDED\"},{\"id\":14,\"name\":\"test\",\"description\":\"да\"}]";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(expected, content.ToString());
        }
    }
}
