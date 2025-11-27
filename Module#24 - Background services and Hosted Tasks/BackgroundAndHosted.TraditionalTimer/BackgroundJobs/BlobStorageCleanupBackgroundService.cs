

namespace BackgroundAndHosted.TraditionalTimer.BackgroundJobs;

public class BlobStorageCleanupBackgroundService(ILogger<BlobStorageCleanupBackgroundService> logger)
: BackgroundService
{
    // private readonly TimeSpan _interval = TimeSpan.FromHours(6);
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Cleanup background service is starting {time}.", DateTimeOffset.UtcNow);

        // Simulate work Recommended way
        while (!stoppingToken.IsCancellationRequested)
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
            await Task.Delay(_interval, stoppingToken);
        }


        // Not recommended way
        // return Task.Run(async () =>
        // {
        //     while (!stoppingToken.IsCancellationRequested)
        //     {
        //         logger.LogInformation("Cleanup background service is working {time}.", DateTimeOffset.UtcNow);
        //         await Task.Delay(_interval, stoppingToken);
        //     }
        // }, stoppingToken);
    }
}