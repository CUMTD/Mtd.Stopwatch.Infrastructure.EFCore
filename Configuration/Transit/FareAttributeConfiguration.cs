using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class FareAttributeConfiguration : IEntityTypeConfiguration<FareAttribute>
	{
		public void Configure(EntityTypeBuilder<FareAttribute> builder)
		{
			_ = builder
				.ToTable("FareAttribute", "transit");

			_ = builder
				.HasKey(a => a.Id);

			_ = builder
				.Property(a => a.Id)
				.HasColumnName("Id")
				.HasMaxLength(20)
				.IsRequired();

			_ = builder
				.Property(a => a.Price)
				.HasColumnName("Price")
				.HasPrecision(9, 4)
				.IsRequired();

			_ = builder
				.Property(a => a.Currency)
				.HasColumnName("Currency")
				.HasMaxLength(10)
				.IsRequired();

			_ = builder
				.Property(a => a.CanPrepay)
				.HasColumnName("CanPrepay")
				.IsRequired();

			_ = builder
				.Property(a => a.Transfers)
				.HasColumnName("Transfers")
				.IsRequired();
		}
	}
}
