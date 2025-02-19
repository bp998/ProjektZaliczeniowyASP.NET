
// Co robi app.UseMiddleware<RequestLoggingMiddleware>();?

// Przechwytuje każde żądanie HTTP.
// Loguje metodę (GET, POST, PUT, DELETE) oraz ścieżkę (/api/StudentApi).
// Mierzy czas wykonania żądania.

using System.Diagnostics;


namespace ProjektZaliczeniowyASP.NET.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            
            _logger.LogInformation($"[{context.Request.Method}] {context.Request.Path} - Request started");

            await _next(context); 

            stopwatch.Stop();
            _logger.LogInformation($"[{context.Request.Method}] {context.Request.Path} - Completed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
