using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionsProject
{
    public class ManageMoviesUsingDictionary
    {
        Dictionary<int, Movie> d = new Dictionary<int, Movie>();
        
        private int GenerateId()
        {
            if (d.Count == 0)
                return 1;
            List<int> ids = d.Keys.ToList();
            ids.Sort();
            int id=  ids[ids.Count - 1];
            id++;
            return id;
        }
        public Movie CreateMovie()
        {
            Movie movie = new Movie();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        public Movie GetMovieIndexById(int id)
        {
            //List<KeyValuePair<int, Movie>> myList = d.ToList();
            //return myList.FindIndex(m => m.Key == id);//Lambda expression
            if(d.ContainsKey(id))
            {
                Movie getDet = d[id];
                return getDet;
            }
            else
            {
                Console.WriteLine("not present");
                return null;
            }
        }
        public Movie UpdateMovieName(int id, string name)
        {
            Movie movie = GetMovieIndexById(id);
            if (movie!=null)
            {
                d[id].Name = name;
                movie = d[id];
            }
            return movie;
        }
        private void PrintMovieById()
        {
            Console.WriteLine("Please enter the movie id to be Printed");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie movie= GetMovieIndexById(id);
            if (movie != null)
                PrintMovie(movie);
            else
                Console.WriteLine("No such movie");
        }
        private void DeleteMovie()
        {
            Console.WriteLine("Please enter the movie id to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie movie = GetMovieIndexById(id);
            if (movie != null)
                d.Remove(id);

            else
            {
                Console.WriteLine("Oops something went wrong. Please try again");
            }
        }
        public Movie UpdateMovieDuration(int id, double duration)
        {
            Movie movie = GetMovieIndexById(id);
            if (movie != null)
            {
                d[id].Duration = duration;
                movie = d[id];
            }
            return movie;
        }
        
        public void PrintAllMovies()
        {
            if (d.Count == 0)
                Console.WriteLine("No movies present.");
            else
            {
                foreach (var item in d.Keys)
                {
                    PrintMovie(d[item]);
                }
            }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                Movie movie = CreateMovie();
                int Id = GenerateId();
                d.Add(Id,movie);
                Console.WriteLine("Do you wish to add another movie?? if yes enter any number other than 0. To exit enter 0");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Not a correct input");
                }

            } while (choice != 0);
        }
        public void SortMovies()
        {
            if (d.Count != 0)
            {
                foreach (KeyValuePair<int, Movie> duration in d.OrderBy(key => key.Value))
                {
                    Console.WriteLine("sorted");
                }
                //List<int> Duration = d.Keys.ToList();
                //Duration.Sort();
                Console.WriteLine("sorted");
            }
            else
                Console.WriteLine("No elements to be sorted");
        }
        public void PrintMovie(Movie movie)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(movie);
            Console.WriteLine("------------------------");
        }
        void UpdateMovie()
        {
            Console.WriteLine("Please enter the movie id for updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do u want to update name or duration or both");
            string choice = Console.ReadLine();
            string name;
            double duration;
            switch (choice)
            {
                case "name":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid entry for duration. Please try again");
                    }

                    UpdateMovieDuration(id, duration);
                    break;
                case "both":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid entry for duration. Please try again");
                    }

                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Add a list of movies");
                Console.WriteLine("3. Update the movie");
                Console.WriteLine("4. Delete the movie");
                Console.WriteLine("5. Print movie by ID");
                Console.WriteLine("6. Print all movies");
                Console.WriteLine("7. Sort movies");
                Console.WriteLine("8. Exit the application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Movie movie = CreateMovie();
                        int Id = GenerateId();
                        d.Add(Id, movie);
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovies();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 8);
        }

        static void Main(string[] s)
        {
             //new ManageMoviesDic().AddItemsToDictionary();
             new ManageMoviesUsingDictionary().PrintMenu();
             Console.ReadKey();
        }
    }
}
