using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;
using Travelers.Shared.Infrastructure.Persistence.EFC.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Domain.Model.ValueObjects;
using Travelers.Subscriptions.Domain.Repositories;

namespace Travelers.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context) : BaseRepository<Plan>(context), IPlanRepository
{
    public bool ExistsByName(string name)
    {
        return Context.Set<Plan>().Any(x => x.Name == name);
    }

    public bool ExistsByIsDefault()
    {
        return Context.Set<Plan>().Any(x => x.IsDefault == new IsDefault(1));
    }
}