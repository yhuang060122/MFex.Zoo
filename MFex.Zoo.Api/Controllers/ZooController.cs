using MFex.Zoo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFex.Zoo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZooController : ControllerBase
    {
        private readonly IZooUseCase _zooUseCase;

        public ZooController(IZooUseCase zooUseCase)
        {
            _zooUseCase = zooUseCase;
        }

        [HttpGet("Spends")]
        public IActionResult GetSpends()
        {
            var spends = _zooUseCase.CalculSpends();

            return Ok(spends);
        }
    }
}