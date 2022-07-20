namespace SimpleConsole.Data
{
    using System.Collections.Generic;

    public partial class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }
}
