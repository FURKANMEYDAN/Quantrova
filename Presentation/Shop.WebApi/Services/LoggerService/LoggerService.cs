using Shop.Domain.Entities;
using Shop.Persistence.Context;

namespace Shop.WebApi.Services.LoggerService
{
    public class LoggerService<T> : ILoggerService<T>
    {
        private readonly ShopContext _context;  
        private readonly ILogger<T> _logger;

        public LoggerService(ShopContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
         public async Task LogError(string message, Exception ex)
        {
            _logger.LogError(message, ex);
            await AddError("Error:", message, ex?.ToString());
        }

        private async Task AddError(string v1, string message, string? exception)
        {
            var log = new Log
            {
                Exception = exception,
                Message = message,
                TimeStamp = DateTime.UtcNow,
            };

            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task LogInfo(string message)
        {
            _logger.LogInformation(message);
            await AddInfo("Info:", message);
        }

        private async Task AddInfo(string v, string message)
        {
            var log = new Log
            {
                Message = message,
                TimeStamp = DateTime.UtcNow,
            };

            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
