namespace Books.Models
{
    public static class MemoryDb
    {
        public static List<Book> Books { get; set; } = new()
        {
             new Book {Title = "Pride and Prejudice", Year = 1813, Author="Jane Austen"},
             new Book {Title = "To Kill a Mockingbird", Year = 1960, Author="Harper Lee"},
             new Book {Title = "The Great Gatsby", Year = 1925, Author="F. Scott Fitzgerald "},
             new Book {Title = "Moby-Dick", Year = 1851, Author="Herman Melville"},
        };
    }

}
