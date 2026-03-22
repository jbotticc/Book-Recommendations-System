using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepo _memberRepo;

    public MemberService(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
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
}