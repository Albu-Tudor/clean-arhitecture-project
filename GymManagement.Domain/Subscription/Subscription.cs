namespace GymManagement.Domain.Subscription
{
    public class Subscription
    {
        private readonly Guid _adminId;

        public Guid Id { get; private set; }
        public SubscriptionType SubscriptionType { get; private set; }

        public Subscription(
            SubscriptionType subscriptionType,
            Guid adminId,
            Guid? id = null)
        {
            Id= Guid.NewGuid();
            _adminId = adminId;
            SubscriptionType = subscriptionType;
        }

        private Subscription()
        { 
        }
    }
}
