using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Api
{
	internal class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
	{
		public void Configure(EntityTypeBuilder<ApiKey> builder)
		{
			_ = builder
					.ToTable("ApiKey", "api");

			_ = builder
				.HasKey(ak => ak.Key);

			_ = builder
				.Property(ak => ak.Key)
				.HasMaxLength(36)
				.IsRequired();

			_ = builder
				.Property(ak => ak.DeveloperId)
				.IsRequired();

			_ = builder
				.Property(ak => ak.Name)
				.HasMaxLength(100)
				.IsRequired();

			_ = builder
				.Property(ak => ak.Notes)
				.IsRequired(false);

			_ = builder
				.Property(ak => ak.IsActive)
				.HasDefaultValue(true)
				.IsRequired();

			_ = builder
				.HasOne(ak => ak.Developer)
				.WithMany(d => d.ApiKeys)
				.HasForeignKey(ak => ak.DeveloperId);

		}
	}
}
