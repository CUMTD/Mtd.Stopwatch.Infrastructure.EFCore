using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class FleetVehicleConfiguration : IEntityTypeConfiguration<FleetVehicle>
	{
		public void Configure(EntityTypeBuilder<FleetVehicle> builder)
		{
			_ = builder.ToTable("FleetVehicle", "transit");

			// Compound Key
			_ = builder.HasKey(fv => new { fv.Id, fv.FleetId });

			_ = builder
				.Property(fv => fv.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(fv => fv.FleetId)
				.HasColumnName("FleetId")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(fv => fv.IsActive)
				.HasColumnName("IsActive")
				.IsRequired();

			_ = builder
				.Property(fv => fv.ImportTime)
				.HasColumnName("ImportTime")
				.IsRequired();

			_ = builder
				.HasOne<Fleet>()
				.WithMany()
				.HasForeignKey(fv => fv.FleetId)
				.IsRequired();

			_ = builder
				.HasMany(fv => fv.Attributes)
				.WithOne()
				.IsRequired(false);

		}
	}
}
