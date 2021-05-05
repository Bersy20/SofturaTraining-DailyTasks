using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = "server=LAPTOP-Q1S49BFG;Integrated security=true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        void FetchAllMoviesFromDatabase()
        {
            string strCmd = "Select * from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0]);
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void FetchOneMovieFromDatabase()
        {
            string strCmd = "Select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Enter Id ");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void AddMovie()
        {
            //insert into tblMovie(name,duration) values('X-Men',123.2)
            Console.WriteLine("Enter movie name ");
            string mName = Console.ReadLine();
            Console.WriteLine("Enter movie duration ");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "insert into tblMovie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie  inserted");
                else
                    Console.WriteLine("no no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                con.Close();
            }
        }
        void UpdateMovieDuration()
        {
            //Update tblMovie set duration=@mduration where id=@mid 
            Console.WriteLine("Enter movie id ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter movie duration ");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration=@mduration where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mduration", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Duration updated");
                else
                    Console.WriteLine("no no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                con.Close();
            }
        }
        void UpdateMovieName()
        {
            //Update tblMovie set name=@mname where id=@mid 
            Console.WriteLine("Enter movie id ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter movie New Movie Name  ");
            string mname = Console.ReadLine();
            string strCmd = "Update tblMovie set name=@mname where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mname", mname);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Name updated");
                else
                    Console.WriteLine("no no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                con.Close();
            }
        }

        void UpdateMovie()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Choose what you want to update if You dont want to update press 0??");
                Console.WriteLine("1. Movie Name ");
                Console.WriteLine("2. Movie Duration ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            UpdateMovieName();
                            break;
                        case 2:
                            UpdateMovieDuration();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                    PrintMenu();
            } while (choice != 2);

        }
        void DeleteMovieById()
        {
            //delete from tblMovie where id=@mid
            Console.WriteLine("Enter movie id ");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie deleted");
                else
                    Console.WriteLine("no no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                con.Close();
            }
        }
        void SortMoviesByName()
        {
            //select * from tblMovie order by @mname
            
            string strCmd = "select * from tblMovie order by name";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0]);
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                con.Close();
            }
        }
        public void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Fetch All Movie names");
                Console.WriteLine("3. Fetch one movie by id ");
                Console.WriteLine("4. Update Movie");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Sort Movies By Name");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter the choice ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchAllMoviesFromDatabase();
                        break;
                    case 3:
                        FetchOneMovieFromDatabase();
                        break;
                    case 4:
                        UpdateMovie();
                        break;
                    case 5:
                        DeleteMovieById();
                        break;
                    case 6:
                        SortMoviesByName();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Please enter valid Choice!!");
                        break;
                }
            } while (choice != 6);

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program program = new Program();
            //program.AddMovie();
            //program.FetchAuthorsFromDatabase();
            //program.FetchOneMovieFromDatabase();
            //program.UpdateMovieDuration();
            //program.DeleteMovieById();
            program.PrintMenu();
        }
    }
}
