using FluentAssertions;
using MobileBackend.Repositories;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MobileBackend.Mappers;
using AutoMapper;
using MobileBackend.Models.Domain;

namespace MobileBackend.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAsync_should_invoke_add_async_once_on_repository()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object, mapper.Object);
            await userService.RegisterAsync("user1@email.com", "userroZorro","secret");

            userRepoMock.Verify(n => n.AddAsync(It.IsAny<User>()), Times.Once);

        }
    }
}
