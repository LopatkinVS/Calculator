using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers.Abstract
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public abstract class BaseApiController : Controller
    { }
}
