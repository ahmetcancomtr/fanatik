using System.Threading.Tasks;
using fanatik.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fanatik.extention;

namespace fanatik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;
        
        public TestController(ILogger<TestController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        [Route("echo")]
        [FrontAuth]
        public  async Task<TestModel> Echo(TestModel request)
        {
            return request;
        }        
    }
}
