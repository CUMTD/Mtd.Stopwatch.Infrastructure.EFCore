using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule
{
	internal class PublicRouteConfiguration : IEntityTypeConfiguration<PublicRoute>
	{
		public void Configure(EntityTypeBuilder<PublicRoute> builder)
		{
			_ = builder
				.ToTable("PublicRoute", "schedule");

			_ = builder
				.HasKey(a => a.Id);

			_ = builder
				.HasOne(pr => pr.PublicRouteGroup)
				.WithMany(rg => rg.PublicRoutes)
				.HasForeignKey(pr => pr.PublicRouteGroupId)
				.IsRequired();

			_ = builder
				.HasOne(pr => pr.Daytype)
				.WithMany(dt => dt.Routes)
				.HasForeignKey(pr => pr.DaytypeId)
				.IsRequired();
		}
	}
}
