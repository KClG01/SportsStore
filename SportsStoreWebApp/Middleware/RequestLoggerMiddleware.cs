using System.Diagnostics;

namespace SportsStoreWebApp.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context){
            Console.WriteLine($"---> Request đến: {context.Request.Method}{ context.Request.Path}");

            await _next(context);

            Console.WriteLine($"<--- Response trả về: {context.Request.Method} { context.Request.Path} với Status: { context.Response.StatusCode}");
        }
    }
}
