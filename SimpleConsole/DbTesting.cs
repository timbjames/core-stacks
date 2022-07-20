namespace SimpleConsole
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using SimpleConsole.Data;
    using SimpleConsole.Models;

    public static class DbTesting
    {
        public static void AddBlog()
        {
            using var db = new BloggingContext();

            Console.WriteLine($"Database path: {db.DbPath}");

            // Create
            Console.WriteLine("Inserting new blog");
          
            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            db.SaveChanges();            
        }

        public static void ReadBlog(IMapper mapper)
        {
            using var db = new BloggingContext();
                        
            // Read
            Console.WriteLine("Querying for a blog");
            //var blog = db.Blogs
            //    .TagWith("Reading Blogs")
            //    .Include(x => x.Posts)
            //    .OrderBy(x => x.BlogId).First();

            //var blogExists1 = db.Blogs
            //    .TagWith("Using ANY")
            //    .Any(x => x.BlogId == 2);

            //var blogExists2 = db.Blogs
            //    .TagWith("Using FirstORDefault")
            //    .FirstOrDefault(x => x.BlogId == 2) != null;

            //var blogExists3 = db.Blogs
            //    .TagWith("Using SingleOrDefault")
            //    .SingleOrDefault(x => x.BlogId == 2) != null;

            //Console.WriteLine($"blog url: {blog.Url}");

            //if (blog.Posts.Any())
            //{
            //    blog.Posts.ForEach(x =>
            //    {
            //        Console.WriteLine($"Post: {x.Title}");
            //    });
            //}

            var blog = db.Blogs
                .Where(b => b.BlogId == 2)
                .ProjectTo<BlogExtra>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            Console.WriteLine(blog.BlogName);
        }

        public static void UpdateBlog()
        {
            using var db = new BloggingContext();

            var blog = db.Blogs.First();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://google.com";
            blog.Posts.Add(new Post
            {
                Content = "Hello World",
                Title = "Hello World"
            });

            db.SaveChanges();
        }

        public static void DeleteBlog()
        {
            using var db = new BloggingContext();

            var blog = db.Blogs.First();

            // Delete
            Console.WriteLine("Delete the blog");

            db.Remove(blog);
            db.SaveChanges();
        }
    }
}
