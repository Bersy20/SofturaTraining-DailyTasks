using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVCwithADO2.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorID,Price from tbl_Books", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewBook(string Title,int aid,double Price)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorID", aid);
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable DisplayAuthors()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select AuthorID,AuthorName from tbl_author",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int InsertNewAuthor(string authorName)
        {
            SqlConnection con = new SqlConnection("data source=.;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", authorName);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}