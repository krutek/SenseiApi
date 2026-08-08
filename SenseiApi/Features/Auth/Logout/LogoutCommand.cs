using MediatR;

namespace SenseiApi.Features.Auth.Logout
{
    public record LogoutCommand(
       string RefreshToken
   ) : IRequest;
}
