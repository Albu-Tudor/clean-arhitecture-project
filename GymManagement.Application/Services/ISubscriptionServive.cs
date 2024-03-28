namespace GymManagement.Application.Services
{
    public interface ISubscriptionServive
    {
        Guid CreateSubscription(string subscriptionType, Guid adminId);
    }
}
