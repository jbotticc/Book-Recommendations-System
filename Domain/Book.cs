namespace BookRecommendationsSystem.Domain;

public class Book
{
    public int Isbn { get; }
    public string Author { get; }
    public string Title { get; }
    public string Year { get; }

    public Book(string author, string title, string year, int isbn)
    {
        if (isbn <= 0)
            throw new ArgumentException("ISBN must be greater than 0");
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentNullException(nameof(author));
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
        if (string.IsNullOrWhiteSpace(year)) throw new ArgumentNullException(nameof(year));
        Isbn = isbn;
        Author = author;
        Title = title;
        Year = year;
    }
}