namespace BookRecommendationsSystem.Contracts;

public interface ILoginService
{
    /// <summary>
    /// Logs in the user given the account number
    /// </summary>
    /// <param name="account">The account number of the user logging in</param>
    /// <exception cref="ArgumentException">Thrown when the account number does not match an existing user</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A user must exist with the provided account number
    ///
    /// Post-conditions:
    /// - Logs in the user with the account id
    /// </remarks>
    void LogInUser(int account);
    
    /// <summary>
    /// Logs out the currently logged in user
    /// </summary>
    void LogOutUser();

    /// <summary>
    /// A method to retrieve the account number of the user logged in
    /// </summary>
    /// <returns>The account number of the user logged in</returns>
    int GetLoggedIn();
}