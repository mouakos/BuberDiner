using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
    {
        #region Public methods declaration

        public void Configure(EntityTypeBuilder<MenuReview> builder)
        {
            builder.ToTable("MenuReviews");

            builder.HasKey(mr => mr.Id);

            builder.Property(mr => mr.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuReviewId.Create(value));

            builder.OwnsOne(mr => mr.Rating);

            builder.Property(mr => mr.Comment)
                .HasMaxLength(500);

            builder.Property(mr => mr.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            builder.Property(mr => mr.MenuId)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.Property(mr => mr.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder.Property(mr => mr.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));
        }

        #endregion
    }
}