namespace BookRecommendationsSystem.Domain;

public class Book
{
    private int _isbn;

    public int Isbn
    {
        get => _isbn;
        private set => _isbn = value;
    }

    public string Author { get; }
    public string Title { get; }
    public string Year { get; }

    public Book(string author, string title, string year)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentNullException(nameof(author));
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
        if (string.IsNullOrWhiteSpace(year)) throw new ArgumentNullException(nameof(year));
        Author = author;
        Title = title;
        Year = year;
    }
    
    internal void SetIsbn(int isbn)
    {
        Isbn = isbn;
    }
}