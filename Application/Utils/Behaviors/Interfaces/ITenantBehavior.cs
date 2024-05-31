using MediatR;

namespace Application.Utils.Behaviors.Interfaces
{
    public interface ITenantBehavior<TResponse> : IRequest<TResponse>
    {
        string SlugTenant { get; set; }
    }
}
