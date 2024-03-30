using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using DomainSubscriptionType = GymManagement.Domain.Subscription.SubscriptionType;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISender _mediator;

        public SubscriptionsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionRequest request)
        {
            if (!DomainSubscriptionType.TryFromName(
                request.SubscriptionType.ToString(), 
                out var subscriptionType))
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "Invalid SubscriptionType");
            }
            
            var command = new CreateSubscriptionCommand(
                subscriptionType,
                request.AdminId);

            var createSubscriptionResult = await _mediator.Send(command);

            return createSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
                error => Problem()
            );
        }

        [HttpGet("{subcrtiptionId}")]
        public async Task<IActionResult> Get([FromRoute] Guid subcrtiptionId)
        {
            var query = new GetSubscriptionQuery(subcrtiptionId);

            var getSubscriptionResult = await _mediator.Send(query);

            return getSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(
                    subscription.Id, 
                    Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
                error => Problem());
        }
    }
}
