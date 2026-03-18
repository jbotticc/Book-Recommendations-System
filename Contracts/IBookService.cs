using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IBookService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    void AddBook(Book book);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    void UpdateBook(Book book);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    void DeleteBook(int isbn);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    Book GetBook(int isbn);
}