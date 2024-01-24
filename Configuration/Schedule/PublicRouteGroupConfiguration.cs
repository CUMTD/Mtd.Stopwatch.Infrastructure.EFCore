using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule
{
	internal class PublicRouteGroupConfiguration : IEntityTypeConfiguration<PublicRouteGroup>
	{
		public void Configure(EntityTypeBuilder<PublicRouteGroup> builder)
		{
			_ = builder
					.ToTable("PublicRouteGroup", "schedule");
			_ = builder
					.HasKey(a => a.Id);
			_ = builder
				.HasOne(rg => rg.Direction)
				.WithMany()
				.HasForeignKey(rg => rg.DirectionId)
				.IsRequired();

			_ = builder
				.Ignore(rg => rg.ActivePublicRoutes);
		}
	}
}
