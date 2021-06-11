using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace ExploreBD
{
    class Program
    {
      
        //TASK 1
       
        public void SelectingBooks()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from tbl_Books";
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
                Console.WriteLine(reader["BookID"]+" "+reader["Title"]+" "+reader["Price"].ToString());
            con.Close();
            Console.ReadLine();
        }
        public void InsertingBooks()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Insert into tbl_Books(Title,AuthorID,Price) values(@Title,@AuthorID,@Price)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Title", "Five Point Someone");
            cmd.Parameters.AddWithValue("@AuthorID", 1);
            cmd.Parameters.AddWithValue("@Price", 400);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatingBooks()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update tbl_Books set Price=@Price where BookID=@BookID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Price", 1000);
            cmd.Parameters.AddWithValue("@BookID", 1000);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeletingBooks()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete from tbl_Books where BookID=@BookID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BookID", 1014);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SelectingAuthors()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            string qry = "select * from tbl_author";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
                Console.WriteLine(reader["AuthorID"]+" "+reader["AuthorName"]);
            con.Close();
        }
        public void InsertingAuthors(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            string qry = "Insert into tbl_author(AuthorName) values(@AuthorName)";
            SqlCommand cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatingAuthors(int aid,string name)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true ");
            string qry = "Update tbl_author set AuthorName=@AuthorName where AuthorID=@AuthorID";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = name;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeletingAuthors(int Au_Id)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            string query = "Delete from tbl_author where AuthorID=@AuthorID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Au_Id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // TASK 3

        public void InsertingBooksSP()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_InsertBook",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", "Five Point Someone");
            cmd.Parameters.AddWithValue("@AuthorID", 1);
            cmd.Parameters.AddWithValue("@Price", 400);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatingBooksSP()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdateBook",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Price", 1000);
            cmd.Parameters.AddWithValue("@BookID", 1000);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeletingBooksSP()
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", 1015);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void InsertingAuthorsSP(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatingAuthorsSP(int aid, string name)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true ");
            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = name;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeletingAuthorsSP(int Au_Id)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Au_Id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.InsertBooks();
            //obj.UpdateBooks();
            //obj.BookSP("Sivagamiyin Sabatham", 2, 970);
            //SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated security=true");
            //SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //    Console.WriteLine(rdr["BookId"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());
            //con.Close();


            //obj.InsertingBooks();
            //obj.SelectingBooks();
            //obj.UpdatingBooks();
            //obj.DeletingBooks();

            //obj.InsertingAuthors("Charles Dickens");
            //obj.UpdatingAuthors(9, "Ruskin Bond");
            //obj.DeletingAuthors(9);
            //obj.SelectingAuthors();

            //obj.InsertingBooksSP();
            //obj.UpdatingBooksSP();
            //obj.DeletingBooksSP();

            //obj.InsertingAuthorsSP("Charles Dickens");
            //obj.UpdatingAuthorsSP(11, "Ruskin Bond");
            obj.DeletingAuthorsSP(11);

            Console.ReadLine();

        }
    }
}
