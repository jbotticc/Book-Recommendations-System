using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IMemberService
{
    /// <summary>
    /// A method available to the user to add a new member
    /// </summary>
    /// <param name="name">The name of the member being added</param>
    /// <exception cref="ArgumentException">Thrown when the name is null or empty</exception>
    void AddMember(string name);
    
    /// <summary>
    /// A method available to the user to update an existing member
    /// </summary>
    /// <param name="account">The account id of the member being updated</param>
    /// <param name="name">The new name of the member being updated</param>
    /// <exception cref="ArgumentException">Thrown when the provided account id does not match a user</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A user with the provided account id must exist
    ///
    /// Post-conditions:
    /// - The user with the provided account id has their name changed to the new value
    /// </remarks>
    void UpdateMember(int account, string name);
    
    /// <summary>
    /// A method available to the user to delete an existing member
    /// </summary>
    /// <param name="account">The account id of the member to delete</param>
    /// <exception cref="ArgumentException">Thrown when the provided account id does not match a user</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A user with the provided account id must exist
    ///
    /// Post-conditions:
    /// - The user with the provided account id is deleted
    /// </remarks>
    void DeleteMember(int account);
    
    /// <summary>
    /// A method available to the user to retrieve a member
    /// </summary>
    /// <param name="account">The account id of the member to retrieve</param>
    /// <exception cref="ArgumentException">Thrown when the provided account id does not match a user</exception>
    /// <returns>
    /// A member object
    /// </returns>
    /// <remarks>
    /// Pre-conditions:
    /// - A user must exist with the provided account id
    ///
    /// Post-conditions:
    /// - The member object with the provided account id is returned
    /// </remarks>
    Member GetMember(int account);
}