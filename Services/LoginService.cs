using BookRecommendationsSystem.Contracts;

namespace BookRecommendationsSystem.Services;

public class LoginService : ILoginService
{
    private readonly IMemberRepo _memberRepo;
    private int _loggedIn;

    public LoginService(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
        _loggedIn = 0;
    }

    public void LogInUser(int account)
    {
        if (_loggedIn != 0)
        {
            throw new InvalidOperationException("A user is already logged in");
        }
        
        _memberRepo.Get(account);
        _loggedIn = account;
    }

    public void LogOutUser()
    {
        if (_loggedIn == 0)
        {
            throw new InvalidOperationException("No one is logged in");
        }
        
        _loggedIn = 0;
    }

    public int GetLoggedIn()
    {
        return _loggedIn;
    }
}