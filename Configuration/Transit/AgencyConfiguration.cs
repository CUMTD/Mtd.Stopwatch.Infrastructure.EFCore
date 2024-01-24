using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit
{
	internal class AgencyConfiguration : IEntityTypeConfiguration<Agency>
	{
		public void Configure(EntityTypeBuilder<Agency> builder)
		{
			_ = builder
				.ToTable("Agency", "transit");

			_ = builder
				.HasKey(a => a.Id);

			_ = builder
				.Property(a => a.Id)
				.HasColumnName("Id")
				.HasMaxLength(20)
				.IsRequired();

			_ = builder
				.Property(a => a.Name)
				.HasColumnName("Name")
				.IsRequired();

			_ = builder
				.Property(a => a.Url)
				.HasColumnName("Url")
				.IsRequired();

			_ = builder
				.Property(a => a.Timezone)
				.HasColumnName("Timezone")
				.HasMaxLength(100)
				.IsRequired();

			_ = builder
				.Property(a => a.Language)
				.HasColumnName("Language")
				.HasMaxLength(10)
				.IsRequired();

			_ = builder
				.Property(a => a.Phone)
				.HasColumnName("Phone")
				.HasMaxLength(20)
				.IsRequired();

			_ = builder
				.Property(a => a.FareUrl)
				.HasColumnName("FareUrl")
				.IsRequired(false);

			_ = builder
				.Property(a => a.Email)
				.HasColumnName("Email")
				.IsRequired();
		}
	}
}
