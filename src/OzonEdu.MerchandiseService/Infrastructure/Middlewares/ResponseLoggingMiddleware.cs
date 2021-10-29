using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (string.Equals(context.Request.Protocol, "HTTP/1.1"))
            {
                TryWriteLog(context);
            }
            else
            {
                await _next(context);
            }
        }

        private async void TryWriteLog(HttpContext context)
        {
            try
            {
                var originalBodyStream = context.Response.Body;
                await using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;
                await _next(context);
                var response = await ResponseLog(context.Response);
                await responseBody.CopyToAsync(originalBodyStream);
                _logger.LogInformation(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not log Response");
            }
        }

        private async Task<string> ResponseLog(HttpResponse response)
        {
            var headers = response.Headers.Select(item => $"{item.Key} : {item.Value}");
            var headersAsText = string.Join(Environment.NewLine, headers);
            
            string bodyAsText = string.Empty;
            if (response.Body.Length > 0)
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                string body = await new StreamReader(response.Body).ReadToEndAsync();
                response.Body.Seek(0, SeekOrigin.Begin);
                bodyAsText = $"---Body---{Environment.NewLine}{response.StatusCode}: {body}";
            }
            
            var answer = new List<string> { "Response log:", "---Headers---", headersAsText, bodyAsText };
            return string.Join(Environment.NewLine, answer);
        }
    }
}