namespace BookRecommendationsSystem.Domain;

public class Member
{
    private string _name;

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

    public int Account { get; }
    
    public Member(string name, int account)
    {
        Name = name;
        Account = account;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
