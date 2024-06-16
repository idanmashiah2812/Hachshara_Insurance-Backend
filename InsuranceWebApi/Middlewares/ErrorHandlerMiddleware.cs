using InsuranceWebApi.Logger;

namespace InsuranceWebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                CustomLogger.Instance.Info($"{context.Request.Method} -> {context.Request.Body}");
                await _next(context);
            }
            catch (Exception e)
            {
                CustomLogger.Instance.Error(context.TraceIdentifier, e);

                context.Response.Clear();
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }
}
