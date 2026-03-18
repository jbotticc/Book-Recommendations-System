namespace BookRecommendationsSystem.Contracts;

public interface IRecommendationService
{
    /// <summary>
    /// Prints the calculated recommendations to the console for the user who is signed in.
    /// </summary>
    void PrintRecommendations();
}