using Travelers.Shared.Domain.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Domain.Model.ValueObjects;

namespace Travelers.Subscriptions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    bool ExistsByName(string name);
    bool ExistsByIsDefault();
}