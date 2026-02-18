using Microsoft.AspNetCore.Mvc;
using UniqueStringApi.Services;

namespace UniqueStringApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniqueStringController : ControllerBase
    {
        private readonly IUniqueStringGenerator _uniqueStringGenerator;

        public UniqueStringController(IUniqueStringGenerator uniqueStringGenerator)
        {
            _uniqueStringGenerator = uniqueStringGenerator;
        }


        [HttpGet]
        public ActionResult<string> Get()
        {
            var uniqueString = _uniqueStringGenerator.Generate();
            return Ok(uniqueString);
        }


        [HttpGet("json")]
        public ActionResult<object> GetJson()
        {
            var uniqueString = _uniqueStringGenerator.Generate();
            return Ok(new { uniqueString, timestamp = System.DateTime.UtcNow });
        }
    }
}
