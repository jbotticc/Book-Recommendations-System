namespace BookRecommendationsSystem.Contracts;

public interface ILoginService
{
    /// <summary>
    /// Logs in the user given the account number
    /// </summary>
    /// <param name="account">The account number of the user logging in</param>
    /// <exception cref="InvalidOperationException">Thrown when a user is already logged in</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the account number does not match an existing user</exception>
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
    /// <exception cref="InvalidOperationException">Thrown when no one is logged in</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A user must be logged in
    ///
    /// Post-conditions:
    /// - Logs out the user
    /// </remarks>
    void LogOutUser();

    /// <summary>
    /// A method to retrieve the account number of the user logged in
    /// </summary>
    /// <returns>The account number of the user logged in</returns>
    int GetLoggedIn();
}