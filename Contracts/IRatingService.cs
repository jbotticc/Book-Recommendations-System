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
    /// Adds a new rating object to a users list of ratings with a default rating of 0
    /// </summary>
    /// <param name="account">The account id of the user who is getting a rating added</param>
    /// <param name="isbn">The isbn of the book to add a rating to</param>
    /// <exception cref="KeyNotFoundException">Thrown when the provided account id does not match an existing member or the provided isbn does not match an existing book</exception>
    void AddRating(int account, int isbn);
    
    /// <summary>
    /// A method available to the user to update a rating for a book
    /// </summary>
    /// <param name="account">The account id of the user who is updating a rating</param>
    /// <param name="isbn">The isbn of the book to be rated</param>
    /// <param name="rating">The integer value of the rating</param>
    /// <exception cref="ArgumentException">Thrown when the provided rating value is not one of the following: -5, -3, 0, 1, 3, or 5</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the provided account id does not match an existing member or the provided isbn does not match an existing book</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - The provided isbn must correlate to an existing book
    /// - The provided rating must be one of the following: -5, -3, 0, 1, 3, or 5
    ///
    /// Post-conditions:
    /// - The rating for the book represented by the isbn is updated to the new rating value
    /// - </remarks>
    void UpdateRating(int account, int isbn, int rating);
    
    /// <summary>
    /// A method available to the user to delete a rating for a book
    /// </summary>
    /// <param name="account">The account id of the user who is deleting a rating</param>
    /// <param name="isbn">The given isbn corresponding to the rating to be deleted</param>
    /// <exception cref="KeyNotFoundException">Thrown if isbn does not match an existing book</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - The provided isbn must correlate to an existing book
    /// - The provided account must correlate to an existing member
    ///
    /// Post-conditions:
    /// - The rating for the book represented by the isbn is deleted
    /// - </remarks>
    void DeleteRating(int account, int isbn);
    
    /// <summary>
    /// A method available to the user to display ratings given an account id
    /// </summary>
    /// <param name="account">The account id of the member whose ratings to retrieve</param>
    /// <exception cref="KeyNotFoundException">Thrown when the provided account id does not match an existing member</exception>
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

    /// <summary>
    /// A method available to the user to get a specific rating
    /// </summary>
    /// <param name="account">The account id of the member whose rating to retrieve</param>
    /// <param name="isbn">The isbn of the book whose rating to retrieve</param>
    /// <exception cref="KeyNotFoundException">Thrown if account does not match an existing member</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the isbn does not match an existing book</exception>
    /// <returns>
    /// The rating value
    /// </returns>
    int GetRating(int account, int isbn);
}