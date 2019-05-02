using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;

namespace MobileBackend.Controllers
{
    public class TestController : ApiControllerBase
    {
        public TestController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }

        [HttpGet]
        [Authorize]
        [Route("checkIfLogged")]
        public IActionResult OnAuth()
        {
            return Ok();
        }
    }
}