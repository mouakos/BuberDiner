using BuberDinner.Domain.BillAggregate;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.GuestAggregate;
using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuReviewAggregate;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence
{
    public class BuberDinnerDbContext(
        DbContextOptions<BuberDinnerDbContext> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor) : DbContext(options)
    {
        #region Public properties declaration

        public DbSet<Bill> Bills { get; set; } = null!;
        public DbSet<Dinner> Dinners { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;
        public DbSet<Host> Hosts { get; set; } = null!;
        public DbSet<MenuReview> MenuReviews { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        #endregion

        #region Protected methods declaration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        #endregion
    }
}