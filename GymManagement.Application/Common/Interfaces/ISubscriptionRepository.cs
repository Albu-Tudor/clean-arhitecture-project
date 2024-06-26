﻿using GymManagement.Domain.Subscription;

namespace GymManagement.Application.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task AddSubscriptionAsync(Subscription subscription);
        Task<Subscription?> GetSubscriptionAsync(Guid subscriptionId);
        Task RemoveSubscriptionAsync(Subscription subscription);
    }
}
