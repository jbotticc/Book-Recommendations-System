namespace BookRecommendationsSystem.Contracts;

public interface ISeedService
{
    /// <summary>
    /// A method to seed data given a file path.
    /// Seeds data into the respective repo using
    /// the respective service
    /// </summary>
    /// <param name="path">The path of the file to be parsed</param>
    /// <exception cref="FileNotFoundException">Thrown when an incorrect file path is entered</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - File path must exist
    ///
    /// Post-conditions:
    /// - The respective types repository gets data seeded into it
    /// </remarks>
    void SeedData(string path);
}