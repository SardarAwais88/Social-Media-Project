using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Social_Media_Project.Models;

namespace Social_Media_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

  /*      public RegistrationController(IConfiguration configuration)
        {
            
        }*/
        public  EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddEvents")]

        public Response AddNews(Events events)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.AddEvent(events, connection);
            return response;
        }


        [HttpGet]
        [Route("EventList")]

        public Response EventList()
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.EventsList(connection);
            return response;
        }
    }
}
