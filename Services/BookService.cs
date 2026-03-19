using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class BookService : IBookService
{
    public void AddBook(string author, string title, string year)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(int isbn, string author, string title, string year)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(int isbn)
    {
        throw new NotImplementedException();
    }

    public Book GetBook(int isbn)
    {
        throw new NotImplementedException();
    }
}