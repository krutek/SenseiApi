using MediatR;

namespace SenseiApi.Features.Auth.Login
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapLoginEndpoint(
            this IEndpointRouteBuilder app)
        {
            app.MapPost(
                "/auth/login",
                async (
                    LoginCommand command,
                    ISender sender) =>
                {
                    var result = await sender.Send(command);

                    return Results.Ok(result);
                })
                .WithName("Login")
                .WithTags("Authentication");

            return app;
        }
    }
}
