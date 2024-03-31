using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscription;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly GymManagementDbContext _dbContext;

        public SubscriptionRepository(GymManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
        }

        public async Task<Subscription?> GetSubscriptionAsync(Guid subscriptionId)
        {
            var subscription = await _dbContext.Subscriptions.FindAsync(subscriptionId);

            return subscription;
        }

        public Task RemoveSubscriptionAsync(Subscription subscription)
        {
            _dbContext.Remove(subscription);

            return Task.CompletedTask;
        }
    }
}
