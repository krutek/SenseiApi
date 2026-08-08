using MediatR;
using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly AppDbContext _dbContext;

        public RegisterHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            bool exists = await _dbContext.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);

            if (exists)
            {
                throw new Exception("User with this email already exists.");
            }
            string hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                hash);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new RegisterResponse(user.Id, user.Email);

        }

    }
}
