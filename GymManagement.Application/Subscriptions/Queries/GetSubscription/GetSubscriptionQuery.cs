using ErrorOr;

using GymManagement.Domain.Subscription;

using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription
{
    public record GetSubscriptionQuery(
        Guid subscriptionId) : IRequest<ErrorOr<Subscription>>;
}
