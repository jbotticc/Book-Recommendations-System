using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepo _memberRepo;
    private readonly IRatingService _ratingService;

    public MemberService(IMemberRepo memberRepo, IRatingService ratingService)
    {
        _memberRepo = memberRepo;
        _ratingService = ratingService;
    }
    
    public void AddMember(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Member name cannot be null or empty");
        }

        int id = _memberRepo.GetNextId();
        Member member = new Member(name, id);
        _memberRepo.Add(member);
        _ratingService.AddAccount(id);

        // Add default rating entry of 0 for all books for this new member
        int isbn = 1;
        while (isbn != -1)
        {
            try
            {
                _ratingService.AddRating(id, isbn);
                isbn++;
            }
            catch (KeyNotFoundException)
            {
                isbn = -1;
            }
            
        }
    }

    public void UpdateMember(int account, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Member name cannot be null or empty");
        }
        
        Member member = _memberRepo.Get(account);
        member.SetName(name);
    }

    public void DeleteMember(int account)
    {
        _memberRepo.Get(account);
        _memberRepo.Delete(account);
    }

    public Member GetMember(int account)
    {
        return _memberRepo.Get(account);
    }

    public int GetMemberCount()
    {
        return _memberRepo.GetMemberCount();
    }
}