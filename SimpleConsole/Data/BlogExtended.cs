namespace SimpleConsole.Data
{
    public class BlogExtended
    {
        public int BlogExtendedId { get; set; }
        public int? BlogId { get; set; }

        public string Name { get; set; }
        public Blog Blog { get; set; }
    }
}
