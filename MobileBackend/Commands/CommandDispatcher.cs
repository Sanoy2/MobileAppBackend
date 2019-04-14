using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext context;

        public CommandDispatcher(IComponentContext context)
        {
            this.context = context;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is null)
            {
                throw new ArgumentNullException(nameof(command), "Command cannot be null");
            }

            var handler = context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
