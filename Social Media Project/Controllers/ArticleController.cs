using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Social_Media_Project.Models;

namespace Social_Media_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /*      public RegistrationController(IConfiguration configuration)
              {

              }*/
        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddArticle")]

        public Response AddArticle(Article article)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.AddArticle(article, connection);
            return response;
        }


        [HttpGet]
        [Route("ArticleList")]

        public Response ArticleList(Article article)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.ArticleList(article, connection);
            return response;
        }

        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Registration registration)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.UserApproval(registration, connection);

            return response;
        }

    }
}
