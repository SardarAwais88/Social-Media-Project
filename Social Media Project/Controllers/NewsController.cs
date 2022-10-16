using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Social_Media_Project.Models;

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

        [HttpPost]
        [Route("AddNews")]

        public Response AddNews(News news)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.AddNews(news, connection);
            return response;
        }


        [HttpGet]
        [Route("NewsList")]

        public Response NewsList(News news)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.AddNews(news, connection);
            return response;
        }
    }
}
