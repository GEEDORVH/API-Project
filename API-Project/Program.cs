using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using Xunit.Sdk;
using System.Configuration;

namespace ApiTest
{
    public class Program
    {
        
        public ITestOutputHelper _logger;
        
        public Program (ITestOutputHelper outputHelper)
        {
            _logger = outputHelper;
        }
        [Fact]
        public async Task TestGet()
        {
            
            var client = new HttpClient();
            var response = await client.GetAsync("https://reqres.in/api/users/2");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }
        }
        [Fact]
        public async Task TestPost()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://reqres.in/api/users");

            var user = new Employee 

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }
        }

        [Fact]
        public async Task Test()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://reqres.in/api/users?page=2");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }
        }
    }
}