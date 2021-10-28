using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                var headers = new List<string>();
                foreach (var value in context.Request.Headers)
                {
                    headers.Add($"{value.Key} : {value.Value}");
                }

                var log = new List<string>
                {
                    "Request log:",
                    $"Path: {context.Request.Path.Value}",
                    $"Headers:",
                    $" {string.Join("\n ", headers)}",
                };
            
                _logger.LogInformation(string.Join("\n", log));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request headers");
            }
        }
    }
}