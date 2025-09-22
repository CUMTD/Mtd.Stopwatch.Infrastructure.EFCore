using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit
{
	public class FleetVehicleRepository(StopwatchContext context)
		: AsyncEFIdentifiableRepository<string, FleetVehicle>(context), IFleetVehicleRepository<IReadOnlyCollection<FleetVehicle>>
	{
		public async Task<IReadOnlyCollection<FleetVehicle>> GetAllActiveAsync(CancellationToken cancellationToken)
		{
			var results = await Query()
				.Include(fv => fv.Attributes)
				.ToArrayAsync(cancellationToken);

			return results.ToImmutableArray();
		}
	}
}
