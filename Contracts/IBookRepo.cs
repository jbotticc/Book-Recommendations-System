using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IBookRepo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    void Add(Book book);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    void Update(Book book);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    void Delete(int isbn);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    Book Get(int isbn);
}