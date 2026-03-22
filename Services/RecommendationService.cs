using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IRatingService _ratingService;
    private readonly IMemberService _memberService;
    private readonly IBookService _bookService;
    private readonly ILoginService _loginService;

    public RecommendationService(IRatingService ratingService, IMemberService memberService, IBookService bookService, ILoginService loginService)
    {
        _ratingService = ratingService;
        _memberService = memberService;
        _bookService = bookService;
        _loginService = loginService;
    }

    private Member CalculateSimilarity(int memberId, List<Rating> ratings)
    {
        int comparisonId = 1;
        int maxSimilarity = 0;
        Member bestMatch = null;
        while (comparisonId != -1)
        {
            if (comparisonId == memberId)
            {
                comparisonId++;
                continue;
            }
            try
            {
                _memberService.GetMember(comparisonId);
                var otherRatings = _ratingService.GetRatingsById(comparisonId);
                int similarity = 0;
                for (int i = 0; i < ratings.Count; i++)
                {
                    similarity += ratings[i].RatingVal * otherRatings[i].RatingVal;
                }
                if (similarity > maxSimilarity)
                {
                    maxSimilarity = similarity;
                    bestMatch = _memberService.GetMember(comparisonId);
                }
                comparisonId++;
            }
            catch (KeyNotFoundException)
            {
                comparisonId = -1;
            }

        }
        return bestMatch;
    }

    public void PrintRecommendations()
    {
        var member = _loginService.GetLoggedIn();
        var ratings = _ratingService.GetLoggedInUsersRatings();
        var bestMatch = CalculateSimilarity(member, ratings);
        if (bestMatch == null)
        {
            Console.WriteLine("No recommendations available. Please rate more books.");
            return;
        }
        var bestMatchRatings = _ratingService.GetRatingsById(bestMatch.Account);
        Console.WriteLine("You have a similar taste as " + bestMatch.Name);
        Console.WriteLine("Here are the books they really liked:");
        for (int i = 0; i < bestMatchRatings.Count; i++)
        {
            if (bestMatchRatings[i].RatingVal == 5 && ratings[i].RatingVal == 0)
            {
                var book = _bookService.GetBook(i + 1);
                Console.WriteLine(book.Isbn + ", " + book.Author + ", " + book.Title + ", " + book.Year);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Here are the books they liked:");
        for (int i = 0; i < bestMatchRatings.Count; i++)
        {
            if (bestMatchRatings[i].RatingVal == 3 && ratings[i].RatingVal == 0)
            {
                var book = _bookService.GetBook(i + 1);
                Console.WriteLine(book.Isbn + ", " + book.Author + ", " + book.Title + ", " + book.Year);
            }
        }

    }
}