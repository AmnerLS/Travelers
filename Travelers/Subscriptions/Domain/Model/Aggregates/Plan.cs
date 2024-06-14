using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Domain.Model.ValueObjects;

namespace Travelers.Subscriptions.Domain.Model.Aggregates;

public class Plan
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public MaxUsers MaxUsers { get; private set; }
    public IsDefault IsDefault { get; private set; }

    public Plan()
    {
        Name = string.Empty;
        MaxUsers = new MaxUsers(0);
        IsDefault = new IsDefault(0);
    }
    public Plan(string name, int maxUsers, int isDefault)
    {
        Name = name;
        MaxUsers = new MaxUsers(maxUsers);
        IsDefault = new IsDefault(isDefault);
    }
    
    public Plan(CreatePlanCommand command) : this(command.Name, command.MaxUsers, command.IsDefault)
    { }
    
}