using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscription;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace GymManagement.Infrastructure.Common.Persistence
{
    public class GymManagementDbContext : DbContext, IUnitOfWork
    {
        public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; } = null!;

        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
