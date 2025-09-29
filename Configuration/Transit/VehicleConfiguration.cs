using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			_ = builder.ToTable("Vehicle", "transit");

			// Compound Key
			_ = builder.HasKey(fv => fv.Id);

			_ = builder
				.Property(fv => fv.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(fv => fv.VehicleNumber)
				.HasColumnName("VehicleNumber")
				.HasMaxLength(50)
				.IsRequired();

			_ = builder
				.Property(fv => fv.VehicleConfigurationId)
				.HasColumnName("VehicleConfigurationId")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(fv => fv.IsActive)
				.HasColumnName("IsActive")
				.IsRequired();

			_ = builder
				.Property(fv => fv.VIN)
				.HasColumnName("VIN")
				.IsRequired();
			_ = builder
				.Property(fv => fv.LicensePlateNumber)
				.HasColumnName("LicensePlateNumber")
				.IsRequired();

			_ = builder
				.HasOne<Core.Entities.Transit.VehicleConfiguration>()
				.WithMany()
				.HasForeignKey(fv => fv.VehicleConfigurationId)
				.IsRequired();

			_ = builder
				.HasMany(fv => fv.Attributes)
				.WithOne(a => a.Vehicle)
				.HasForeignKey(a => a.VehicleId)
				.IsRequired();

		}
	}
}
