namespace SolutionReservation.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.AddFile("RequestLogs.txt").CreateLogger("RequestLogging");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);

            await _next(context);
        }

        private void LogRequest(HttpContext context)
        {
            var userType = context.Request.Path.Value.Contains("/admin", StringComparison.OrdinalIgnoreCase) ? "Administrator" : "User";

            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} => {context.Response.StatusCode} - User Type: {userType}");
        }
    }

}
