using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher commandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }
    }
}
