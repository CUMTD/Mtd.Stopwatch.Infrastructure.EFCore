using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class ShapePointConfiguration : IEntityTypeConfiguration<ShapePoint>
	{
		public void Configure(EntityTypeBuilder<ShapePoint> builder)
		{
			_ = builder
				.ToTable("ShapePoint", "transit");

			_ = builder
				.HasKey(s => new { s.ShapeId, s.Sequence });

			_ = builder
				.Property(s => s.ShapeId)
				.HasColumnName("ShapeId")
				.HasMaxLength(60)
				.IsRequired();

			_ = builder
				.Property(s => s.Sequence)
				.HasColumnName("sequence")
				.IsRequired();

			_ = builder
				.Property(t => t.Latitude)
				.HasColumnName("Latitude")
				.IsRequired();

			_ = builder
				.Property(t => t.Longitude)
				.HasColumnName("Longitude")
				.IsRequired();

			_ = builder
				.Property(s => s.DistanceTraveled)
				.HasColumnName("DistnaceTraveled")
				.HasPrecision(9, 3)
				.IsRequired();

			_ = builder
				.HasOne(t => t.Shape)
				.WithMany(s => s.Points)
				.HasForeignKey(t => t.ShapeId);
		}
	}
}
