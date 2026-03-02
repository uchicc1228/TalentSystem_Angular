using Microsoft.Extensions.Logging;

namespace TalentApi.Helper
{
    public static class LogHelper
    {
        public static void Info(ILogger logger, string message)
        {
            logger.LogInformation($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public static void Warn(ILogger logger, string message)
        {
            logger.LogWarning($"[WARN] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public static void Error(ILogger logger, string message, Exception? ex = null)
        {
            logger.LogError(ex, $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}
