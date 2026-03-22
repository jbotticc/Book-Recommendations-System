using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IRatingService
{
    /// <summary>
    /// A method to add a new account to the repository
    /// </summary>
    /// <param name="account">The account id of the new user</param>
    void AddAccount(int account);
    
    /// <summary>
    /// Adds a new rating object to a users list of ratings
    /// </summary>
    /// <param name="account">The account id of the user who is getting a rating added</param>
    /// <param name="isbn">The isbn of the book to add a rating to</param>
    void AddRating(int account, int isbn);
    
    /// <summary>
    /// A method available to the user to update a rating for a book
    /// </summary>
    /// <param name="isbn">The isbn of the book to be rated</param>
    /// <param name="rating">The integer value of the rating</param>
    /// <exception cref="InvalidOperationException">Thrown when there is no user logged in</exception>
    /// <exception cref="ArgumentException">Thrown when the provided rating value is not between 0 and 5</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - The provided isbn must correlate to an existing book
    /// - The provided rating must be between 1 and 5
    ///
    /// Post-conditions:
    /// - The rating for the book represented by the isbn is updated to the new rating value
    /// - </remarks>
    void UpdateRating(int isbn, int rating);
    
    /// <summary>
    /// A method available to the user to delete a rating for a book
    /// </summary>
    /// <param name="isbn">The given isbn corresponding to the rating to be deleted</param>
    /// <exception cref="InvalidOperationException">Thrown when there is no user logged in</exception>
    void DeleteRating(int isbn);
    
    /// <summary>
    /// A method available to the user to display ratings given an account id
    /// </summary>
    /// <returns>
    /// A list of rating objects
    /// </returns>
    List<Rating> GetRatingsById(int account);
    
    /// <summary>
    /// A method available to the user to display their ratings
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown where there is no user logged in</exception>
    /// <returns>
    /// A list of rating objects
    /// </returns>
    List<Rating> GetLoggedInUsersRatings();
}