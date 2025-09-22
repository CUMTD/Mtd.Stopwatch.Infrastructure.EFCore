using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class FleetConfiguration : IEntityTypeConfiguration<Fleet>
	{
		public void Configure(EntityTypeBuilder<Fleet> builder)
		{
			_ = builder.ToTable("Fleet", "transit");

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
				.Property(f => f.DateInService)
				.HasColumnName("DateInService")
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
				.Property(f => f.IsActive)
				.HasColumnName("IsActive")
				.IsRequired();

			_ = builder
				.Property(f => f.IsPublic)
				.HasColumnName("IsPublic")
				.IsRequired();

			_ = builder
				.Property(f => f.ImportTime)
				.HasColumnName("ImportTime")
				.IsRequired();

			_ = builder
				.HasMany(f => f.Vehicles)
				.WithOne()
				.IsRequired(false);

		}
	}
}
