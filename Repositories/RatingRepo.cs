using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Repositories;

public class RatingRepo : IRatingRepo
{
    private readonly Dictionary<int, List<Rating>> _ratings = new();
    
    public void Add(Rating rating, int account)
    {
        throw new NotImplementedException();
    }

    public void Update(Rating rating, int account)
    {
        throw new NotImplementedException();
    }

    public void Delete(int isbn, int account)
    {
        throw new NotImplementedException();
    }
    
    public List<Rating> Get(int account)
    {
        throw new NotImplementedException();
    }
}