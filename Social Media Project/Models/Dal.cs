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
    }
}
