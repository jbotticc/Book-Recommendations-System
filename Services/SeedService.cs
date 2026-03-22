namespace BookRecommendationsSystem.Services;
using BookRecommendationsSystem.Contracts;

public abstract class SeedService : ISeedService
{

    protected string[] ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found at {path}");
        }
        return File.ReadAllLines(path);
    }

    public abstract void SeedData(string path);

}