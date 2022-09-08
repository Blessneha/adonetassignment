using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp8
{
    internal class Q2
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-45DGQP0R\SQLEXPRESS;Initial Catalog=Adoassign1;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        public void addmovie(int MovieId,string Name,int year,string Lang,string Director,string Actor)
        {
            try
            {

                string query = $"insert into Movie values({MovieId},'{Name}',{year},'{Lang}','{Director}','{Actor}')";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void GetMoviesByName(string name) //get product by Id
        {
            
            try
            {
                string query = $"Select MovieId,Name,year,Lang,Director from Movie where Name='{name}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("MovieId:{0} ,Name:{1} ,year:{2}, Lang{3}, Director{4},Actor{5}",dr["MovieId"],dr["Name"],dr["year"],dr["Lang"],dr["Director"],dr["Actor"]);

                }
                else
                    Console.WriteLine("Invalid name");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetallMovies()
        {
            try
            {
                string query = "Select * from Movie";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("MovieId:{0} ,Name:{1} ,year:{2}, Lang{3}, Director{4},Actor{5}", dr["MovieId"], dr["Name"], dr["year"], dr["Lang"], dr["Director"], dr["Actor"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteProduct(int MovieId) //delete product
        {
            try
            {
                
                    string query= $"Delete from Movie where MovieId={MovieId}";
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateProduct(int MovieId, int year,string Actor,string Director) //update product 
        {
            try
            {
                string query = $"Update Movie set year={year},Actor='{Actor}',Director='{Director}' Where MovieId={MovieId}";
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void GetAllMoviesByActor(string actor)
        {
            
            string qry = $"Select MovieId,Name,year,Lang,Director,Actor from Movie where Actor='{actor}'";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "Movie");
            Console.WriteLine("Movie records");
            foreach (DataRow row in ds.Tables["Movie"].Rows)
            {
                Console.WriteLine("MovieId:{0} ,Name:{1} , year:{2}, Lang:{3} , Director:{4},Actor:{5}",row["MovieId"],row["Name"],row["year"],row["Lang"],row["Director"],row["Actor"]);
            }
            
        }

        public void GetAllMoviesByDirector(string director)
        {

            string qry = $"Select MovieId,Name,year,Lang,Director,Actor from Movie where Director='{director}'";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "Movie");
            Console.WriteLine("Movie records");
            foreach (DataRow row in ds.Tables["Movie"].Rows)
            {
                Console.WriteLine("MovieId:{0} ,Name:{1} , year:{2}, Lang:{3} , Director:{4},Actor:{5}", row["MovieId"], row["Name"], row["year"], row["Lang"], row["Director"], row["Actor"]);
            }

        }
    }
}
