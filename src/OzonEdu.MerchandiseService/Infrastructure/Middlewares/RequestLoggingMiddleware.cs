using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
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

        public async Task InvokeAsync(HttpContext context)
        {
            if (!string.Equals(context.Request.Headers["Content-Type"], "application/grpc"))
            {
                TryWriteLog(context);
            }
            await _next(context);
        }

        private async void TryWriteLog(HttpContext context)
        {
            try
            {
                var request = await RequestLog(context.Request);
                _logger.LogInformation(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not log Request");
            }
        }

        private async Task<string> RequestLog(HttpRequest request)
        {
            var headers = request.Headers.Select(item => $"{item.Key} : {item.Value}");
            var headersAsText = string.Join(Environment.NewLine, headers);

            string bodyAsText = string.Empty;
            if (request.ContentLength > 0)
            {
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var body = Encoding.UTF8.GetString(buffer);
                request.Body.Position = 0;
                bodyAsText = $"---Body---{Environment.NewLine}{body}";
            }

            var answer = new List<string> { "Request log:", "---Headers---", headersAsText, bodyAsText };
            return string.Join(Environment.NewLine, answer);
        }
    }
}