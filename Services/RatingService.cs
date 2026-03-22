using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class RatingService : IRatingService
{
    private readonly ILoginService _loginService;
    private readonly IMemberRepo _memberRepo;
    private readonly IRatingRepo _ratingRepo;
    private readonly IBookRepo _bookRepo;

    public RatingService(ILoginService loginService, IMemberRepo memberRepo, IRatingRepo ratingRepo, IBookRepo bookRepo)
    {
        _loginService = loginService;
        _memberRepo = memberRepo;
        _ratingRepo = ratingRepo;
        _bookRepo = bookRepo;
    }

    public void AddAccount(int account)
    {
        _ratingRepo.AddAccount(account);
    }
    
    public void AddRating(int account, int isbn)
    {
        _memberRepo.Get(account);
        _bookRepo.Get(isbn);
        Rating rating = new Rating(isbn, 0);
        _ratingRepo.Add(rating, account);
    }   
    
    public void UpdateRating(int isbn, int rating)
    {
        _bookRepo.Get(isbn);
        if (rating is < 0 or > 5)
        {
            throw new ArgumentException("Rating must be between 0 and 5");
        }
        int account = _loginService.GetLoggedIn();
        if (account == 0)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }
       
        Rating newRating = new Rating(isbn, rating);
        _ratingRepo.Update(newRating, account);
    }

    public void DeleteRating(int isbn)
    {
        _bookRepo.Get(isbn);
        int account = _loginService.GetLoggedIn();
        if (account == 0)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }
        _ratingRepo.Delete(isbn, account);
    }

    public List<Rating> GetRatingsById(int account)
    {
        _memberRepo.Get(account);
        return _ratingRepo.Get(account);
    }

    public List<Rating> GetLoggedInUsersRatings()
    {
        int account = _loginService.GetLoggedIn();
        if (account == 0)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }
        return _ratingRepo.Get(account);
    }
}