using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Handlers.Users
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService userService;

        public LoginUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task HandleAsync(LoginUser command)
        {
            var token = await userService.LoginAsync(command.Email, command.Password);
        }
    }
}
