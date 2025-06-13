using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        public AuthController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> AddProducts()
        {
            return Ok();
        }
    }
}
