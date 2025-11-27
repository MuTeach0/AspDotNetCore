using Microsoft.Extensions.Diagnostics.HealthChecks;
using PaymentServiceApi.Data;

namespace PaymentServiceApi.HealthChecks;

public class DBHealthCheck(AppDbContext db) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default) =>
            await db.Database.CanConnectAsync(cancellationToken)
                ? HealthCheckResult.Healthy("Database is reachable.")
                : HealthCheckResult.Unhealthy("Database is unreachable.");
}