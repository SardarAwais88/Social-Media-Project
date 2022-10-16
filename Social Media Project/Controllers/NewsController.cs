using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Social_Media_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

  /*      public RegistrationController(IConfiguration configuration)
        {
            
        }*/
        public  NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
