using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit
{
	public class FleetRepository(StopwatchContext context)
		: AsyncEFIdentifiableRepository<string, Fleet>(context), IFleetRepository<IReadOnlyCollection<Fleet>>
	{
		public async Task<IReadOnlyCollection<Fleet>> GetAllActiveAsync(CancellationToken cancellationToken)
		{
			var results = await Query()
				.Include(f => f.Vehicles)
				.ToArrayAsync(cancellationToken);

			return results.ToImmutableArray();
		}
	}
}
