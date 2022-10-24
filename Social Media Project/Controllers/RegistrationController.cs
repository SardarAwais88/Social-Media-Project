using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Social_Media_Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Social_Media_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]

        public Response Registration(Registration registration)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.Registration(registration, connection);
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.Login(registration, connection);
            
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

        [HttpPost]
        [Route("StaffRegistration")]

        public Response StaffRegistration(Staff  staff)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.StaffRegistration(staff, connection);
            return response;

        }

        // api for delete staff
        [HttpPost]
        [Route("DeleteStaff")]

        public Response DeleteStaff(Staff staff)
        {
            Response response = new Response();
            // create sql connect
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SnCon").ToString());

            Dal dal = new Dal();
            response = dal.DeleteStaff(staff, connection);
            return response;

        }
    }
}
