using MediatR;

namespace SenseiApi.Features.Auth.Logout;

public static class Endpoint
{
    public static IEndpointRouteBuilder MapLogoutEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/auth/logout",
            async (
                LogoutCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                await sender.Send(
                    command,
                    cancellationToken);

                return Results.NoContent();
            })
            .WithName("Logout")
            .WithTags("Authentication");

        return app;
    }
}