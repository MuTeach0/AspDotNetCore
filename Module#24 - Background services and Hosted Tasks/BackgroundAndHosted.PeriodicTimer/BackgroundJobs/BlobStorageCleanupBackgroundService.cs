namespace BackgroundAndHosted.PeriodicTimer.BackgroundJobs;

using System.Threading;

public class BlobStorageCleanupBackgroundService(ILogger<BlobStorageCleanupBackgroundService> logger)
    : BackgroundService
{
    // private readonly TimeSpan _interval = TimeSpan.FromHours(6);
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Cleanup background service is starting {time}.", DateTimeOffset.UtcNow);
        var periodicTimer = new PeriodicTimer(_interval);


        // Simulate work Recommended way
        while (await periodicTimer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                logger.LogInformation("Cleanup background service is working {time}.", DateTimeOffset.UtcNow);

                await Task.Delay(1000, stoppingToken);

                int OrphanedItemsCount = Random.Shared.Next(1, 10);

                logger.LogInformation("Deleted {count} orphaned Blobs at {time}.",
                    OrphanedItemsCount, DateTimeOffset.UtcNow);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error in FakeBlobCleanupService.");
            }
        }
    }
}