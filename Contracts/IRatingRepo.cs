using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IRatingRepo
{
    /// <summary>
    /// Internal repository method that the seeding service uses to add a new rating object to a given users rating list
    /// </summary>
    /// <param name="rating">The record object to be added</param>
    void Add(Rating rating);

    /// <summary>
    /// Internal repository method that the service uses to change an existing rating value
    /// </summary>
    /// <param name="rating">The new rating object</param>
    void Update(Rating rating);
    
    /// <summary>
    /// Internal repository method that the service uses to delete a rating that matches the given isbn
    /// </summary>
    /// <param name="isbn">The given isbn corresponding to the rating to be deleted</param>
    void Delete(int isbn);
    
    /// <summary>
    /// Internal repository method that the services uses to display all ratings for the logged in user
    /// </summary>
    /// <returns>
    /// A list of rating objects
    /// </returns>
    List<Rating> Get();
}