namespace Travelers.Subscriptions.Domain.Model.ValueObjects;

public record IsDefault
{
    public int Value { get; }
    
    public IsDefault(int value)
    {
        if (value < 0 || value > 1)
            throw new ArgumentException("Is default must be 0 or 1");
        
        Value = value;
    }
}