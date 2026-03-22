using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class BookService : IBookService
{
    private readonly IBookRepo _bookRepo;

    public BookService(IBookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    }
    
    public void AddBook(string author, string title, string year)
    {
        if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(year))
        {
            throw new ArgumentException("Author, title, and year are required.");
        }
        
        int isbn = _bookRepo.GetNextIsbn();
        Book book = new Book(author, title, year, isbn);
        _bookRepo.Add(book);
    }

    public void UpdateBook(int isbn, string author, string title, string year)
    {
        if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(year))
        {
            throw new ArgumentException("Author, title, and year are required.");
        }

        _bookRepo.Get(isbn);
        Book book = new Book(author, title, year, isbn);
        _bookRepo.Update(book);
    }

    public void DeleteBook(int isbn)
    {
        _bookRepo.Get(isbn);
        _bookRepo.Delete(isbn);
    }

    public Book GetBook(int isbn)
    {
        return _bookRepo.Get(isbn);
    }
}