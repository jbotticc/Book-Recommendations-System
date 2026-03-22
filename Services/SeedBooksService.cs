using BookRecommendationsSystem.Contracts;

namespace BookRecommendationsSystem.Services;

public class SeedBooksService : SeedService
{
    private readonly IBookService _bookService;

    public SeedBooksService(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public override void SeedData(string path)
    {
        var data = ReadFile(path);
        foreach (var line in data)
        {
            var splitData = line.Split(',');
            var title = splitData[1].Trim();
            var author = splitData[0].Trim();
            var year = splitData[2].Trim();
            _bookService.AddBook(title, author, year);
        }
    }
}