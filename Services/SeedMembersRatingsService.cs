using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class SeedMembersRatingsService : SeedService
{
    private readonly IRatingService _ratingService;
    private readonly IMemberService _memberService;

    public SeedMembersRatingsService(IRatingService ratingService, IMemberService memberService)
    {
        _ratingService = ratingService;
        _memberService = memberService;
    }
    
    public override void SeedData(string path)
    {
        var data = ReadFile(path);
        // Even indices are members, odd indices are ratings
        int i = 0;
        int account = -1;
        foreach (var line in data)
        {
            if (i % 2 == 0)
            {
                _memberService.AddMember(line.Trim());
                account = _memberService.GetMemberCount();
            }
            else
            {
                var splitData = line.Trim().Split(' ');
                // Ratings are stored in order of ISBN
                int isbn = 1;
                foreach (var r in splitData)
                {
                    _ratingService.UpdateRating(account, isbn, int.Parse(r.Trim()));
                    isbn++;
                }
            }
            i++;
        }
    }
}