using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IMemberService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="member"></param>
    void AddMember(Member member);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="member"></param>
    void UpdateMember(Member member);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    void DeleteMember(int account);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Member GetMember(int account);
}