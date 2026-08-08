using MediatR;
namespace SenseiApi.Features.Auth.Register;

public static class Endpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/auth/register",
            async (
                RegisterCommand command,
                ISender sender) =>
            {
                var result =
                    await sender.Send(command);

                return Results.Created(
                    $"/users/{result.UserId}",
                    result);
            })
             .WithName("Register")
             .WithTags("Authentication");

        return app;
    }
}