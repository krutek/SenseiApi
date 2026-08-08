namespace SenseiApi.Features.Auth.Register
{
    public record RegisterResponse(
    Guid UserId,
    string Email
    );
}
