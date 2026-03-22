namespace BookRecommendationsSystem.Contracts;

public interface IRecommendationService
{
    /// <summary>
    /// Prints the calculated recommendations to the console for the user who is signed in.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when there is no user logged in</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - An account is logged in
    /// 
    /// Post-conditions:
    /// - The recommendations are printed to the console
    /// - </remarks>
    void PrintRecommendations();
}