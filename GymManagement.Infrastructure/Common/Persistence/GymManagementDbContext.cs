using GymManagement.Domain.Subscription;

using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence
{
    public class GymManagementDbContext : DbContext
    {
        public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; } = null!;
    }
}
