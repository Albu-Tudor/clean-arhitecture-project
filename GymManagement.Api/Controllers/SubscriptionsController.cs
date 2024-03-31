using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using DomainSubscriptionType = GymManagement.Domain.Subscription.SubscriptionType;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

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
                subscription => CreatedAtAction(
                    nameof(Get),
                    new { subscriptionId = subscription.Id },
                    new SubscriptionResponse(
                        subscription.Id,
                        ToDto(subscription.SubscriptionType))),
                error => Problem());
        }

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> Get([FromRoute] Guid subscriptionId)
        {
            var query = new GetSubscriptionQuery(subscriptionId);

            var getSubscriptionResult = await _mediator.Send(query);

            return getSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(
                    subscription.Id, 
                    Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
                error => Problem());
        }

        [HttpDelete("{subscriptionId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid subscriptionId)
        {
            var command = new DeleteSubscriptionCommand(subscriptionId);

            var deleteSubscriptionResult = await _mediator.Send(command);

            return deleteSubscriptionResult.Match<IActionResult>(
                _ => NoContent(),
                _ => Problem());
        }

        private static SubscriptionType ToDto(DomainSubscriptionType subscriptionType)
        {
            return subscriptionType.Name switch
            {
                nameof(DomainSubscriptionType.Free) => SubscriptionType.Free,
                nameof(DomainSubscriptionType.Starter) => SubscriptionType.Started,
                nameof(DomainSubscriptionType.Pro) => SubscriptionType.Pro,
                _ => throw new InvalidOperationException()
            };
        }
    }
}
