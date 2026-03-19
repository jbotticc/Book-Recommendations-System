using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IMemberRepo
{
    /// <summary>
    /// An internal method that MemberService uses to add members
    /// </summary>
    /// <param name="member">The member object to be added</param>
    void Add(Member member);
    
    /// <summary>
    /// An internal method that MemberService uses to update members
    /// </summary>
    /// <param name="member">The member object to replace the existing member with the same id</param>
    void Update(Member member);
    
    /// <summary>
    /// An internal method that MemberService uses to delete members
    /// </summary>
    /// <param name="account">The account number of the member to delete</param>
    void Delete(int account);

    /// <summary>
    /// An internal method that MemberService uses to get members
    /// </summary>
    /// <param name="account">The account number of the member to get</param>
    /// <returns>
    /// The member object matching the provided account id
    /// </returns>
    Member Get(int account);
    
    
}