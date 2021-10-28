using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            await LogResponse(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                var headers = new List<string>();
                foreach (var value in context.Response.Headers)
                {
                    headers.Add($"{value.Key} : {value.Value}");
                }

                var log = new List<string>
                {
                    "Response log:",
                    $"Headers:",
                    $" {string.Join("\n ", headers)}",
                };

                _logger.LogInformation(string.Join("\n", log));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response headers");
            }
        }
    }
}