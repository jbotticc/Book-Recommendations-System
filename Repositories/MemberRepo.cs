using BookRecommendationsSystem.Contracts;
using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Repositories;

public class MemberRepo : IMemberRepo
{
    private readonly Dictionary<int, Member> _members = new();
    private int _nextId = 1;

    public int GetNextId()
    {
        return _nextId++;
    }
    
    public void Add(Member member)
    {
        _members.Add(member.Account, member);
    }

    public void Delete(int account)
    {
        _members.Remove(account);
    }

    public Member Get(int account)
    {
        if (!_members.TryGetValue(account, out var member))
        {
            throw new KeyNotFoundException($"Member with account id {account} not found");
        }
        return member;
    }

    public int GetMemberCount()
    {
        return _members.Count;
    }
}