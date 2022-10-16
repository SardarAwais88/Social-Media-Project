using Microsoft.Data.SqlClient;
using System.Data;

namespace Social_Media_Project.Models
{
    public class Dal

    {
        
        // response for registration
       
        public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            // create sql connection
            SqlCommand cmd = new SqlCommand("Insert into Registration(Name,Email, Password,PhoneNo,IsActive,IsApproved)VALUES('" + registration.Name + "','" + registration.Email + "','" + registration.Password + "','" + registration.PhoneNo + "',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successfull";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";
            }
            return response;
        }

        public Response Login(Registration registration, SqlConnection connection)
        {
           SqlDataAdapter da = new SqlDataAdapter
                
                ("Select * from Registration where Email='"+registration.Email +"'and password='"+registration.Password+"'",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successfull";
                Registration reg = new Registration();
                reg.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);

                response.Registration = reg;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login failed ";
                response.Registration = null;
            }
            return response;
        }

        //api for user approval

        public Response UserApproval(Registration registration, SqlConnection connection)
            {
            // based on id we update it
            Response response = new Response();
            SqlCommand cmd = new SqlCommand
                
          ("Update Registration Set IsAppproved =1 WHERE Id ='" + registration.Id+"'AND ISActive=1 ",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User  approval failed";
            }
            return response;
            // cmd.CommandType = CommandType.Text;.



        }

// response for news

public Response News(News news, SqlConnection connection)
            {
            // based on id we update it
            Response response = new Response();
          //  SqlCommand cmd = new SqlCommand();
                
         SqlCommand cmd = new SqlCommand("Insert into News(Title,Content,Email,IsActive,CreatedOn)VALUES('" + news.Title + "','" + news.Content + "','" + news.Email + "','" + news.IsActive + "',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "News Created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "News Creation failed";
            }
            return response;
            // cmd.CommandType = CommandType.Text;.



        }
       
        public Response NewsList(SqlConnection connection)
        {
            Response response= new Response();
            SqlDataAdapter da = new SqlDataAdapter("selelct * from news where IsActive=1",connection);
            DataTable dt =new DataTable();
            da.Fill(dt);
            List<News> lstNews = new List<News>();


        }

    }
}
