using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using Newtonsoft.Json;
using FluentAssertions.Execution;
using System.Net.Http.Json;
using API_Project.Models.Resource;
using API_Project.Models.User;
using API_Project.Models.CreatedUser;

namespace ApiTest
{
    public class Program
    {

        public ITestOutputHelper _logger;

        public Program(ITestOutputHelper outputHelper)
        {
            _logger = outputHelper;
        }

        [Fact]
        public async Task TestGetSingleUser()
        {

            User returnedUser = new User();
            var client = new HttpClient();
            var response = await client.GetAsync("https://reqres.in/api/users/2");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
             
                returnedUser = JsonConvert.DeserializeObject<User>(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }


            using (new AssertionScope())
            {
                returnedUser.data.id.Should().Be(2);
                returnedUser.data.email.Should().Be("janet.weaver@reqres.in");
                returnedUser.data.first_name.Should().Be("Janet");
                returnedUser.data.last_name.Should().Be("Weaver");
                returnedUser.data.avatar.Should().Be("https://reqres.in/img/faces/2-image.jpg");
            }


        }



        [Fact]
        public async Task TestGetSingleResource()
        {

            Resource returnedResource = new Resource();
            var client = new HttpClient();
            var response = await client.GetAsync("https://reqres.in/api/unknown/2");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
                returnedResource = JsonConvert.DeserializeObject<Resource>(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }

            using (new AssertionScope())
            {
                returnedResource.data.id.Should().Be(2);
                returnedResource.data.name.Should().Be("fuchsia rose");
                returnedResource.data.year.Should().Be(2001);
                returnedResource.data.color.Should().Be("#C74375");
                returnedResource.data.pantone_value.Should().Be("17-2031");
            }



        }



        [Fact]
        public async Task TestPostCreateUser()
        {
            CreatedUser createUser = new CreatedUser()

            {
                name = "morpheus",
                job = "leader"
            };

            CreatedUser createdUser = new CreatedUser();

            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://reqres.in/api/users", createUser);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.WriteLine(content);
                createdUser = JsonConvert.DeserializeObject<CreatedUser>(content);
            }
            else
            {
                _logger.WriteLine("Failed");
            }

            using (new AssertionScope())
            {
                createdUser.name.Should().Be("morpheus");
                createdUser.job.Should().Be("leader");
                createdUser.id.Should().BeOfType<string>();

            }

        }

    }
}




