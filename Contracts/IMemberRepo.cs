using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IMemberRepo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="member"></param>
    void Add(Member member);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="member"></param>
    void Update(Member member);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    void Delete(int account);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Member Get(int account);
    
    
}