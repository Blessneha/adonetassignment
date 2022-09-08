using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp8
{
    internal class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-45DGQP0R\SQLEXPRESS;Initial Catalog=Adoassign1;Integrated Security=True");
        SqlCommand cmd = null;



        public void AddProduct(string name, DateTime dob, string hdeg, string jobtitle, string company, string email) //add product
        {
            try
            {

                string query = $"insert into student2 values('{name}','{dob}','{hdeg}','{jobtitle}','{company}','{email}')";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetProductByName(string name) //get product by Id
        {
            try
            {
                string query = $"Select name,dob,hdeg,jobtitle,company,email from student2 where name='{name}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("Name:{0} DOB:{1} degree:{2} job{3} company{4} email{5}", dr["name"], dr["dob"], dr["hdeg"], dr["jobtitle"], dr["company"], dr["email"]);

                }
                else
                    Console.WriteLine("Invalid name");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void Main(string[] args)
        {
            // Program p=new Program();
            // p.AddProduct("Blessy",DateTime.Now, "ff", "ere", "wwe", "ergg");
            //   p.GetProductByName("Blessy");
            Q2 q = new Q2();
            //  q.addmovie(1, "rtt", 2000, "ccc", "xxxx");
            //     q.GetMoviesByName("rtt");
            // q.GetallMovies();
            //q.addmovie(2, "blessy", 2001,"bbb","yyyy","reszona");

            //  q.addmovie(3, "furniture", 2002, "hhjmm", "ekelw","hazel");
            //q.UpdateProduct(1, 2003, "abc", "wers");
            // q.DeleteProduct(3);
            // q.GetAllMoviesByActor("hazel");
            q.GetAllMoviesByDirector("yyyy");
        }
    }
}

       

