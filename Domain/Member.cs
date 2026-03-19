namespace BookRecommendationsSystem.Domain;

public class Member
{
    private string _name;
    private int _account;
    
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.", nameof(value));
            _name = value;
        }
    }

    public int Account
    {
        get => _account;
        private set => _account = value;
    }

    public Member(string name)
    {
        Name = name;
    }

    internal void SetName(string name)
    {
        Name = name;
    }
    internal void SetAccount(int account)
    {
        Account = account;
    }
}
