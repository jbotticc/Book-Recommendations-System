namespace BookRecommendationsSystem.Contracts;

public interface ILoginService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    void LogInUser(int account);
    
    /// <summary>
    /// 
    /// </summary>
    void LogOutUser();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int GetLoggedIn();
}