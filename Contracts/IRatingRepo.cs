using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IRatingRepo
{
    /// <summary>
    /// A method to add a new account to the repository
    /// </summary>
    /// <param name="account">The id of the new account to add</param>
    void AddAccount(int account);
    
    /// <summary>
    /// Internal repository method that the seeding service uses to add a new rating object to a given users rating list
    /// </summary>
    /// <param name="rating">The record object to be added</param>
    /// <param name="account">The user to add the rating to</param>
    void Add(Rating rating, int account);

    /// <summary>
    /// Internal repository method that the service uses to change an existing rating value
    /// </summary>
    /// <param name="rating">The new rating object</param>
    /// <param name="account">The user to add the rating to</param>
    void Update(Rating rating, int account);
    
    /// <summary>
    /// Internal repository method that the service uses to delete a rating that matches the given isbn
    /// </summary>
    /// <param name="isbn">The given isbn corresponding to the rating to be deleted</param>
    /// <param name="account">The user to delete the rating from</param>
    void Delete(int isbn, int account);
    
    /// <summary>
    /// Internal repository method that the services uses to display all ratings for a user
    /// </summary>
    /// <param name="account">The account id of the member whose ratings to retrieve</param>
    /// <exception cref="KeyNotFoundException">Thrown if account does not match an existing member</exception>
    /// <returns>
    /// A list of rating objects
    /// </returns>
    List<Rating> Get(int account);

    /// <summary>
    /// Internal repository method that the services uses to get a specific rating
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