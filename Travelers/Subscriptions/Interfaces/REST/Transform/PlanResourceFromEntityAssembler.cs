using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Interfaces.REST.Resources;

namespace Travelers.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(entity.Id, entity.Name, entity.MaxUsers.Value);
    }
}