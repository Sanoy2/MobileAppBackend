using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MobileBackend.Commands.Users;
using MobileBackend.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobileBackend.Tests.ETE.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer server;
        private readonly HttpClient client; 

        public UsersControllerTests()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_should_be_gave_back()
        {
            var email = "sanoy@email.com";
            var response = await client.GetAsync($"api/users/{email}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().BeEquivalentTo(email);
        }

        [Theory]
        [InlineData("jacek@email.com")]
        [InlineData("placek@email.com")]
        [InlineData("agatka@email.com")]
        [InlineData("grazyna@email.com")]
        public async Task given_invalid_email_should_Not_exist(string email)
        {
            var response = await client.GetAsync($"api/users/{email}");

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task new_user_with_uniqe_email_should_be_register()
        {
            var email = "unique_username@email.com";
            var password = "secret";
            CreateUser newUser = new CreateUser()
            {
                Email = email,
                Password = password
            };

            var payload = GetPayload(newUser);
            var response = await client.PostAsync("api/users", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString()
                .Should()
                .BeEquivalentTo($"api/users/{newUser.Email}");

            var user = await GetUserAsync(newUser.Email);
            user.Email.Should().BeEquivalentTo(newUser.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
