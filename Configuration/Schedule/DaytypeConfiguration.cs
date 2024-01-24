using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule
{
	internal class DaytypeConfiguration : IEntityTypeConfiguration<Daytype>
	{
		public void Configure(EntityTypeBuilder<Daytype> builder)
		{
			_ = builder
				.ToTable("Daytype", "schedule");
			_ = builder
				.HasKey(a => a.Id);

			_ = builder
				.Property(dt => dt.DaysOfWeekString)
				.HasColumnName("DaysOfWeek");
		}
	}
}
