using Travelers.Shared.Domain.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Domain.Model.ValueObjects;
using Travelers.Subscriptions.Domain.Repositories;
using Travelers.Subscriptions.Domain.Services;

namespace Travelers.Subscriptions.Application.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        if(planRepository.ExistsByName(command.Name))
            throw new Exception("Plan with the same name already exists");

        if (planRepository.ExistsByIsDefault() && command.IsDefault == 1)
            throw new Exception("Plan default already exists");
            
        var plan = new Plan(command);
        try
        {
            await planRepository.AddAsync(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the Plan: {e.Message}");
            return null;
        }
    }
}