using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Domain.Model.Commands;

namespace Travelers.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand command);
}