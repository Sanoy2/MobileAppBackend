using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService userService;

        public CreateUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await userService.RegisterAsync(command.Email, command.Username, command.Password);
        }
    }
}
