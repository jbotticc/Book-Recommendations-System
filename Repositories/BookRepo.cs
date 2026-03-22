using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Repositories;

public class BookRepo : IBookRepo
{
    private readonly Dictionary<int, Book> _books = new();
    private int _nextIsbn = 1;

    public int GetNextIsbn()
    {
        return _nextIsbn++;
    }
    
    public void Add(Book book)
    {
        _books.Add(book.Isbn, book);
    }

    public void Update(Book book)
    {
        _books[book.Isbn] = book;
    }

    public void Delete(int isbn)
    {
        _books.Remove(isbn);
    }

    public Book Get(int isbn)
    {
        if (!_books.TryGetValue(isbn, out var book))
        {
            throw new KeyNotFoundException($"Book with ISBN {isbn} not found");
        }
        return book;
    }

    public int GetBookCount()
    {
        return _books.Count;
    }
}