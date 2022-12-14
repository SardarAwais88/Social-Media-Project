using Microsoft.Data.SqlClient;
using System.Data;

namespace Social_Media_Project.Models
{// OUR Dal class communicate with database
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

public Response AddNews(News news, SqlConnection connection)
            {
            // based on id we update it
            Response response = new Response();
            //  SqlCommand cmd = new SqlCommand();

            // SqlCommand cmd = new SqlCommand("Insert into News(Title,Content,Email,IsActive,CreatedOn)VALUES('" + news.Title + "','" + news.Content + "','" + news.Email + "','" + news.IsActive + "',1,0)", connection);*/
            SqlCommand cmd = new SqlCommand("Insert into News(Title,Content,Email,IsActive,CreatedOn)VALUES('" + news.Title + "','" + news.Content + "','" + news.Email +"' ,1,GetDate())", connection);
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
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News news = new News();
                    news.Id=Convert.ToInt32(dt.Rows[i]["ID"]);  
                    news.Title=Convert.ToString(dt.Rows[i]["Title"]);
                    news.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    news.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    news.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    news.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstNews.Add(news);  

                }
                if (lstNews.Count>0)
                {
                    response.StatusCode=200;
                    response.StatusMessage = "News Data found";
                    response.ListNews = lstNews;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "no News Data found";
                    response.ListNews = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no News Data found";
                response.ListNews = null;
            }
            return response;
        }

        // response for article
        public Response AddArticle(Article article, SqlConnection connection)
        {
            // based on id we update it
            Response response = new Response();
            //  SqlCommand cmd = new SqlCommand();

            SqlCommand cmd = new SqlCommand("Insert into Article(Title,Content,Email,Image,IsActive,IsApproved)VALUES('" + article.Title + "','" + article.Content + "','" + article.Email + "','" + article.Image + "',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article Creation failed";
            }
            return response;
            // cmd.CommandType = CommandType.Text;.



        }

        public Response ArticleList(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = null;

            // now we have two scenarios for article
            // than we use condiotional statement
            if (article.type=="User" )
            {
                // if it is user than article will return based on condition

                new SqlDataAdapter("selelct * from Article where Email='"+article.Email+"' And IsActive=1", connection);
            }
            if (article.type == "Page")
            {
                // return all the article
                new SqlDataAdapter("selelct * from Article where IsActive=1", connection);
            }
         //   SqlDataAdapter da = new SqlDataAdapter("selelct * from Article where IsActive=1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Article> lstarticle = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*Article article  = new Article();
                    article.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    article.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    article.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    article.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    article.Image = Convert.ToString(dt.Rows[i]["IsActive"]);
                    article = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstarticle.Add(article);*/
                    Article art = new Article();
                    art.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    art.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    art.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    art.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    art.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    art.Image = Convert.ToString(dt.Rows[i]["Image"]);

                    lstarticle.Add(art);
                   
                }
                if (lstarticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Article Data found";
                    response.ListArticle = lstarticle;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "no article Data found";
                    response.ListArticle = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no article Data found";
                response.ListArticle = null;
            }
            return response;
        }


        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            // based on id we update it
            Response response = new Response();
            SqlCommand cmd = new SqlCommand

          ("Update Article  Set IsAppproved =1 WHERE Id ='" + article.Id + "'AND ISActive=1 ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article  approval failed";
            }
            return response;
            // cmd.CommandType = CommandType.Text;.



        }

        // response for Staffregistration

        public Response StaffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            // create sql connection
            SqlCommand cmd = new SqlCommand("Insert into Staff(Name,Email, Password,IsActive)VALUES('" + staff.Name + "','" + staff.Email + "','" + staff.Password + "','" + staff.IsActive+ "',1)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Registration Successfull";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Registration failed";
            }
            return response;
        }

        // now we create a mehtod for delete a faculity
        public Response DeleteStaff(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            // create sql connection
            SqlCommand cmd = new SqlCommand("Delete  from Staff where Id='" + staff.Id +"' AND IsActive =1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Delete Successfull";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff delelte failed";
            }
            return response;
        }


        // Methods for events

        public Response AddEvent(Events events, SqlConnection connection)
        {
            // based on id we update it
            Response response = new Response();
            //  SqlCommand cmd = new SqlCommand();

            SqlCommand cmd = new SqlCommand("Insert into Events(Title,Content,Email,IsActive)VALUES('" + events.Title + "','" + events.Content + "','" + events.Email + "',1,GetDate())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Events Created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Events Creation failed";
            }
            return response;
            // cmd.CommandType = CommandType.Text;.



        }


        public Response EventsList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  Events where ISACTIVE=1 ", connection);

            // now we have two scenarios for article

            //   SqlDataAdapter da = new SqlDataAdapter("selelct * from Article where IsActive=1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Events> lstevents = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*Article article  = new Article();
                    article.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    article.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    article.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    article.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    article.Image = Convert.ToString(dt.Rows[i]["IsActive"]);
                    article = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstarticle.Add(article);*/
                    Events event_ = new Events();
                    event_.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    event_.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    event_.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    event_.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    event_.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    event_.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);

                    lstevents.Add(event_);

                }
                if (lstevents.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "List Events Data found";
                    response.ListEvents = lstevents;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "no ListEvent Data found";
                    response.ListEvents = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no article Data found";
                response.ListEvents = null;
            }
            return response;
        }
    }
}
