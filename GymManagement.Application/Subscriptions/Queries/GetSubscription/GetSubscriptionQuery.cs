using ErrorOr;

using GymManagement.Domain.Subscription;

using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription
{
    public record GetSubscriptionQuery(
        Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;
}
