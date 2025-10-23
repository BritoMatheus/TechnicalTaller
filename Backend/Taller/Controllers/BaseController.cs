using Microsoft.AspNetCore.Mvc;

namespace Taller.Controllers
{
    public abstract class BaseController
    {
        [NonAction]
        public new IActionResult Response(object data = null)
        {
            return new OkObjectResult(new { data });
        }
    }
}
