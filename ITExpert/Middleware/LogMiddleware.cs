using ITExpert.Models;
using ITExpert.Services.Interfaces;

namespace ITExpert.Middleware
{
    public class LogMiddleware 
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogService logService)
        {
            //Request
            var path = context.Request.Path;
            var method = context.Request.Method;
            var queryString = context.Request.QueryString.Value;

            var requestInfo = new RequestInfo
            {
                Path = path,
                Method = method,
                QueryString = queryString!,
            };

            await logService.LogRequestAsync(requestInfo);

            await _next(context);
        }

        public bool AllowMultiple => true;
    }
}
