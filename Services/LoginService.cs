using BookRecommendationsSystem.Contracts;

namespace BookRecommendationsSystem.Services;

public class LoginService : ILoginService
{
    private readonly IMemberService _memberService;
    private int _loggedIn;

    public LoginService(IMemberService memberService)
    {
        _memberService = memberService;
        _loggedIn = 0;
    }

    public void LogInUser(int account)
    {
        if (_loggedIn != 0)
        {
            throw new InvalidOperationException("A user is already logged in");
        }
        
        _memberService.GetMember(account);
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