using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRecipes(string keyword = null, int page = 1, int perPage = 20)
        {
            return Ok();
        }
    }
}
