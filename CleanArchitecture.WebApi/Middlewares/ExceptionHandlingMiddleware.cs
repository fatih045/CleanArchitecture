using System.Net;
using System.Text.Json;

namespace CleanArchitecture.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionHandlingMiddleware> _logger;

            public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Beklenmeyen bir hata oluştu.");

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Sunucuda bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
                        Detailed = ex.Message // Bunu production ortamında kaldırabilirsin
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            }
        }
    }
