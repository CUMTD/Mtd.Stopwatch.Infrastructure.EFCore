using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class VehicleAttributeConfiguration : IEntityTypeConfiguration<VehicleAttribute>
	{
		public void Configure(EntityTypeBuilder<VehicleAttribute> builder)
		{
			_ = builder.ToTable("VehicleAttribute", "transit");

			// Compound Key
			_ = builder.HasKey(fv => new { fv.VehicleId, fv.Id });

			_ = builder
				.Property(fv => fv.VehicleId)
				.HasColumnName("VehicleId")
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(fv => fv.Id)
				.HasColumnName("Id")
				.HasMaxLength(50)
				.IsRequired();

			_ = builder
				.Property(fv => fv.Value)
				.HasColumnName("Value")
				.HasMaxLength(500)
				.IsRequired();

			//_ = builder
			//	.HasOne<Vehicle>()
			//	.WithMany()
			//	.HasForeignKey(fv => fv.VehicleId)
			//	.IsRequired();

		}
	}
}
