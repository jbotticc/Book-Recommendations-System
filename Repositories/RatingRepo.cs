using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Repositories;

public class RatingRepo : IRatingRepo
{
    private readonly Dictionary<int, List<Rating>> _ratings = new();

    public void AddAccount(int account)
    {
        List<Rating> list = new List<Rating>();
        _ratings.Add(account, list);
    }
    
    public void Add(Rating rating, int account)
    {
        _ratings[account].Add(rating);
    }

    public void Update(Rating rating, int account)
    {
        _ratings[account][rating.Isbn - 1] = rating;
    }

    public void Delete(int isbn, int account)
    {
        Rating rating = new Rating(isbn, 0);
        _ratings[account][isbn] = rating;
    }
    
    public List<Rating> Get(int account)
    {
        return _ratings[account];
    }
}