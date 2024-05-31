namespace API.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length > 1)
            {
                var slugTenant = segments[0];
                context.Items["Tenant"] = slugTenant;
            }

            await _next(context);
        }
    }
}
