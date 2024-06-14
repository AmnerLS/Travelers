using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Interfaces.REST.Resources;

namespace Travelers.Subscriptions.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(resource.Name, resource.MaxUsers, resource.IsDefault);
    }
}