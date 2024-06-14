using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

using Travelers.Subscriptions.Domain.Services;
using Travelers.Subscriptions.Interfaces.REST.Resources;
using Travelers.Subscriptions.Interfaces.REST.Transform;

namespace Travelers.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlansController(IPlanCommandService planCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        var createPlanCommand = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var plan = await planCommandService.Handle(createPlanCommand);
        if (plan is null) return BadRequest();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(planResource);
    }
}