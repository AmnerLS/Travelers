namespace Travelers.Subscriptions.Domain.Model.ValueObjects;

public record MaxUsers
{
    public int Value { get; }
    
    public MaxUsers(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Max users must be greater than 0");

        Value = value;
    }
}