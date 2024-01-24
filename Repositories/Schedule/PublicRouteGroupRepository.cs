using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule
{
	public class PublicRouteGroupRepository(StopwatchContext context)
		: AsyncEFIdentifiableRepository<string, PublicRouteGroup>(context), IPublicRouteGroupRepository<IReadOnlyCollection<PublicRouteGroup>>
	{
		public async Task<IReadOnlyCollection<PublicRouteGroup>> GetAllWithPublicRoutesAsync(CancellationToken cancellationToken)
		{
			var results = await Query()
				.Include(prg => prg.PublicRoutes)
				.ToArrayAsync(cancellationToken)
				.ConfigureAwait(false);

			return results.ToImmutableArray();
		}
		public Task<PublicRouteGroup> GetByIdentityWithPublicRoutesAsync(string identity, CancellationToken cancellationToken) => Query()
			.Where(prg => prg.Id == identity)
			.Include(prg => prg.PublicRoutes)
			.SingleAsync(cancellationToken);
	}
}
