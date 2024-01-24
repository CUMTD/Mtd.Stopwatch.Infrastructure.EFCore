using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class StopTimeConfiguration : IEntityTypeConfiguration<StopTime>
	{
		public void Configure(EntityTypeBuilder<StopTime> builder)
		{
			_ = builder
				.ToTable("StopTime", "transit");

			_ = builder
				.HasKey(st => new { st.TripId, st.StopSequence });

			_ = builder
				.Property(t => t.TripId)
				.HasColumnName("TripId")
				.HasMaxLength(200)
				.IsRequired();

			_ = builder
				.Property(t => t.TripId)
				.HasColumnName("TripId")
				.HasMaxLength(200)
				.IsRequired();

			_ = builder
				.Property(t => t.StopSequence)
				.HasColumnName("StopSequence")
				.IsRequired();

			_ = builder
				.Property(t => t.ArrivalTime)
				.HasColumnName("ArrivalTime")
				.IsRequired();

			_ = builder
				.Property(t => t.DepartureTime)
				.HasColumnName("DepartureTime")
				.IsRequired();

			_ = builder
				.Property(t => t.StopId)
				.HasColumnName("StopId")
				.HasMaxLength(50)
				.IsRequired();

			_ = builder
				.Property(t => t.StopHeadsign)
				.HasColumnName("StopHeadsign")
				.IsRequired(false);

			_ = builder
				.Property(t => t.PickupType)
				.HasColumnName("PickupType")
				.IsRequired();

			_ = builder
				.Property(t => t.DropOffType)
				.HasColumnName("DropOffType")
				.IsRequired();

			_ = builder
				.Property(t => t.Timepoint)
				.HasColumnName("Timepoint")
				.IsRequired();

			_ = builder
				.HasOne(t => t.Stop)
				.WithMany(s => s.StopTimes)
				.HasForeignKey(s => s.StopId)
				.IsRequired();

			_ = builder
				.HasOne(t => t.Trip)
				.WithMany(t => t.StopTimes)
				.HasForeignKey(t => t.TripId)
				.IsRequired();
		}
	}
}
