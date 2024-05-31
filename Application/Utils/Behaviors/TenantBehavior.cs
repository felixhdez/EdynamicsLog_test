using Application.Utils.Behaviors.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Utils.Behaviors
{
    public class TenantBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITenantBehavior<TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var slugTenant = httpContext.Items["Tenant"]?.ToString();

            if (string.IsNullOrEmpty(slugTenant))
            {
                throw new ValidationException("Tenant no encontrado en la URL");
            }

            request.SlugTenant = slugTenant;
            var response = await next();
            return response;
        }
    }
}
