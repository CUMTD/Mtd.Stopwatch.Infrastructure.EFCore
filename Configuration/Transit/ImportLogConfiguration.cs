using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class ImportLogConfiguration : IEntityTypeConfiguration<ImportLog>
	{
		public void Configure(EntityTypeBuilder<ImportLog> builder)
		{
			_ = builder
				.ToTable("ImportLog", "transit");

			_ = builder
				.HasKey(l => l.Id);

			_ = builder
				.Property(l => l.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(l => l.Start)
				.IsRequired();

			_ = builder
				.Property(l => l.Finish)
				.IsRequired(false);

			_ = builder
				.Property(l => l.Success)
				.IsRequired();

			_ = builder
				.Property(l => l.Ticks)
				.IsRequired(false);

			_ = builder
				.Ignore(l => l.ElapsedTime);
		}
	}
}
