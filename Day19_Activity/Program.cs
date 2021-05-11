using EFandLINQProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFandLINQProject
{
    class Program
    {
        PostRepo postRepo;
        CommentRepo commentRepo;
        TweetContext context;
        Program()
        {
            context = new TweetContext();
            commentRepo = new CommentRepo(context);
            postRepo = new PostRepo(context);
        }
        void AddPost()
        {
            Console.WriteLine("Please enter the post Category");
            string category = Console.ReadLine();
            Console.WriteLine("Please enter the post text");
            string text = Console.ReadLine();
            Post post = new Post();
            post.Category = category;
            post.PostText = text;
            if(postRepo.Add(post))
                Console.WriteLine("Post is posted");
            else
                Console.WriteLine("Could not post");
        }
        void PrintPosts()
        {
            var posts = postRepo.GetAll();
            if(posts!=null)
                foreach (var item in posts.ToList())
                {
                    PrintPost(item);
                }
        }
        void PrintPost(Post post)
        {

            Console.WriteLine("Post Id : " + post.Id);
            Console.WriteLine("Post category : "+ post.Category);
            Console.WriteLine("Post : " + post.PostText);
            Console.WriteLine("-----------------------------------------------");
        }
        void AddCommentToPost()
        {
            PrintPosts();
            int id = 0;
            Console.WriteLine("Please enter the id for which you want to comment");
            id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            if(post!=null)
            {
                PrintPost(post);
                Comment comment = TakeComment(id);
                if(commentRepo.Add(comment))
                {
                    Console.WriteLine("comment updated");
                }
            }
        }
        void PrintPostWithComments()
        {
            var postWiseComment = context.Comments.ToList().GroupBy(c => c.PostId);
            foreach (var postComment in postWiseComment)
            {
                int id = postComment.Key;  ;
                Post post = postRepo.Get(id);
                PrintPost(post);
                Console.WriteLine("Comment for this post");
                foreach (var comment in postComment)
                {
                    PrintComment(comment);
                }
                Console.WriteLine("-----------------------------------------------");
            }
            void PrintComment(Comment comment)
            {
                Console.WriteLine("Comment id "+comment.Id);
                Console.WriteLine(comment.CommentText);
            }
        }
        private Comment TakeComment(int pid)
        {
            Comment comment = new Comment();
            comment.PostId = pid;
            Console.WriteLine("Please enter the comment");
            comment.CommentText = Console.ReadLine();
            return comment;
        }
        
        void AddMoreToThePost()
        {
            Console.WriteLine("Please enter the post id to which you want to add");
            int id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            if (post != null)
            {
                Console.WriteLine("Please enter the post text to be added to it");
                string updatetext = Console.ReadLine();
                post.PostText += (" " + updatetext + " ");
                Console.WriteLine("Post is Updated");
                PrintPosts();
            }
            else
            {
                Console.WriteLine("Could Not Find post with this Id");
            }
        }
       
        void UserInterface()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Create Post");
                Console.WriteLine("2. Add comment to post");
                Console.WriteLine("3. View all posts");
                Console.WriteLine("4. View Postwise comment");
                Console.WriteLine("5. Update posts");
                Console.WriteLine("6. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddPost();
                        break;
                    case 2:
                        AddCommentToPost();
                        break;
                    case 3:
                        PrintPosts();
                        break;
                    case 4:
                        PrintPostWithComments();
                        break;
                    case 5:
                        AddMoreToThePost();
                        break;
                    case 6:
                        Console.WriteLine("Exiting..");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().UserInterface();
        }
    }
}
