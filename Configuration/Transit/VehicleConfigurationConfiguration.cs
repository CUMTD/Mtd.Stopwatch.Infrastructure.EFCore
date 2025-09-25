using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class VehicleConfigurationConfiguration : IEntityTypeConfiguration<Core.Entities.Transit.VehicleConfiguration>
	{
		public void Configure(EntityTypeBuilder<Core.Entities.Transit.VehicleConfiguration> builder)
		{
			_ = builder.ToTable("VehicleConfiguration", "transit");

			_ = builder.HasKey(f => f.Id);

			_ = builder
				.Property(f => f.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(f => f.VehicleType)
				.HasColumnName("VehicleType")
				.IsRequired();

			_ = builder
				.Property(f => f.Year)
				.HasColumnName("Year")
				.IsRequired();

			_ = builder
				.Property(f => f.Make)
				.HasColumnName("Make")
				.HasMaxLength(100)
				.IsRequired();

			_ = builder
				.Property(f => f.Model)
				.HasColumnName("Model")
				.HasMaxLength(50)
				.IsRequired();

			_ = builder
				.Property(f => f.LengthFeet)
				.HasColumnName("LengthFeet")
				.IsRequired(false);

			_ = builder
				.Property(f => f.Powertrain)
				.HasColumnName("Powertrain")
				.IsRequired();

			_ = builder
				.Property(f => f.IsPublic)
				.HasColumnName("IsPublic")
				.IsRequired();

			_ = builder
				.HasMany(f => f.Vehicles)
				.WithOne()
				.IsRequired(false);

		}
	}
}
