using Data.Context;
using Hangfire;

namespace ShippingProject.Extensions
{
    public static class LogCleanupScheduler
    {
        public static void ScheduleLogCleanup(IServiceProvider serviceProvider)
        {
            RecurringJob.AddOrUpdate("log-cleanup",
                () => PerformLogCleanup(serviceProvider),
                Cron.Daily);
        }

        public static void PerformLogCleanup(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var cutoffDate = DateTime.UtcNow.AddDays(-15);
            var logsToDelete = dbContext.Logs.Where(log => log.Date < cutoffDate);
            dbContext.Logs.RemoveRange(logsToDelete);
            dbContext.SaveChanges();
        }
    }
}
