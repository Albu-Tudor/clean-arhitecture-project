using ErrorOr;

using GymManagement.Domain.Subscription;

using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(
        string SubscriptionType, 
        Guid adminId) : IRequest<ErrorOr<Subscription>>;
}
