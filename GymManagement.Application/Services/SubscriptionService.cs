
namespace GymManagement.Application.Services
{
    public class SubscriptionService : ISubscriptionServive
    {
        public Guid CreateSubscription(string subscriptionType, Guid adminId)
        {
            return Guid.NewGuid();
        }
    }
}
