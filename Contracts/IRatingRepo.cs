using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IRatingRepo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rating"></param>
    void Add(Rating rating);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    List<Rating> Get();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    /// <param name="rating"></param>
    void Update(int isbn, Rating rating);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    void Delete(int isbn);
}