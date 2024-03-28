using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;

using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionServive _subscriptionServive;

        public SubscriptionsController(ISubscriptionServive subscriptionServive)
        {
            _subscriptionServive = subscriptionServive;
        }

        [HttpPost]
        public IActionResult CreateSubscription(CreateSubscriptionRequest request)
        {
            var subcriptionId = _subscriptionServive.CreateSubscription(
                request.SubscriptionType.ToString(),
                request.AdminId);

            var response = new SubscriptionResponse(
                subcriptionId, 
                request.SubscriptionType);

            return Ok(response);
        }
    }
}
