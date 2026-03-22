using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class RatingService : IRatingService
{
    public void AddRating(int account)
    {
        throw new NotImplementedException();
    }
    
    public void UpdateRating(int isbn, int rating)
    {
        throw new NotImplementedException();
    }

    public void DeleteRating(int isbn)
    {
        throw new NotImplementedException();
    }

    public List<Rating> GetRatingsById(int account)
    {
        throw new NotImplementedException();
    }

    public List<Rating> GetLoggedInUsersRatings()
    {
        throw new NotImplementedException();
    }
}